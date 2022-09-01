using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�W���쐬����N���X
/// </summary>
public class StageCreater : MonoBehaviour, IStageCreater
{
    // �X�e�[�W���쐬�ς݂�
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
    /// �X�e�[�W�쐬�̃��N�G�X�g 
    /// </summary>
    /// <returns>�쐬�\��</returns>
    public bool CreateStageRequest(Tile tile, int verticalSpacing, int horizontalSpacing, int x, int y)
    {
        if (IsCreated) return false;
        {
            StartCoroutine(CreateStageAsync(tile, horizontalSpacing, verticalSpacing, x, y));
            return true;
        }
    }

    /// <summary>
    /// �X�e�[�W�̍쐬
    /// </summary>horizontal
    /// 
    private IEnumerator CreateStageAsync(Tile tile, int verticalSpacing, int horizontalSpacing, int x, int y)
    {
        // ���C�A�E�g�̍쐬
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

        // �t���O�̕ύX
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
