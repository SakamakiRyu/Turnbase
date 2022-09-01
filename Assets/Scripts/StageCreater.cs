using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージを作成するクラス
/// </summary>
public class StageCreater : MonoBehaviour, IStageCreater
{
    // ステージが作成済みか
    public bool IsCreated { get; set; } = false;

    [SerializeField]
    private VerticalLayoutGroup _verticalLayout;

    private List<Tile> _tiles = new List<Tile>();

    private void OnEnable()
    {
        if (!ServiceLocator<IStageCreater>.IsValid)
        {
            ServiceLocator<IStageCreater>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<IStageCreater>.IsValid)
        {
            ServiceLocator<IStageCreater>.UnRegist(this);
        }
    }

    /// <summary>
    /// ステージ作成のリクエスト 
    /// </summary>
    /// <returns>作成可能か</returns>
    public bool CreateStageRequest(Tile tile, int verticalSpacing, int horizontalSpacing, int x, int y)
    {
        if (IsCreated) return false;
        {
            StartCoroutine(CreateStageAsync(tile, horizontalSpacing, verticalSpacing, x, y));
            return true;
        }
    }

    /// <summary>
    /// ステージの作成
    /// </summary>horizontal
    /// 
    private IEnumerator CreateStageAsync(Tile tile, int verticalSpacing, int horizontalSpacing, int x, int y)
    {
        // レイアウトの作成
        var verticalLayout = CreateVericalLayoutGroup(_verticalLayout.transform, verticalSpacing);
        yield return null;

        for (int posY = 0; posY < y; posY++)
        {
            for (int posX = 0; posX < x; posX++)
            {
                if (posX == 0)
                {
                    var horizontalLayout = CreateHorizontalLayoutGroup(verticalLayout.transform, horizontalSpacing);
                }
                var go = Instantiate(tile);
                go.transform.SetParent(horizontalSpacing.transform);
                _tiles.Add(go);
                yield return null;
            }
        }

        // フラグの変更
        IsCreated = true;
        yield return null;
    }

    private VerticalLayoutGroup CreateVericalLayoutGroup(Transform parent, int spacing)
    {
        var verticalLauout = Instantiate(new GameObject(), parent).AddComponent<VerticalLayoutGroup>();
        verticalLauout.spacing = spacing;
        return verticalLauout;
    }

    private HorizontalLayoutGroup CreateHorizontalLayoutGroup(Transform parent, int spacing)
    {
        var horizontalLayout = Instantiate(new GameObject(), parent).AddComponent<HorizontalLayoutGroup>();
        horizontalLayout.spacing = spacing;
        return horizontalLayout;
    }
}
