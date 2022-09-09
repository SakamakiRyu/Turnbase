using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージ作成オブジェクト
/// </summary>
public class StageGenerator : MonoBehaviour
{
    [SerializeField]
    private VerticalLayoutGroup _verLayout;

    [SerializeField]
    private Tile _tile;

    private void Start()
    {
        CreateStage(_verLayout, 5, _tile, 3, 4);
    }

    /// <summary>
    /// ステージを作成
    /// </summary>
    private void CreateStage(VerticalLayoutGroup verticalLayout, int spacing, Tile tile, int column, int raw)
    {
        // 間隔を設定
        verticalLayout.spacing = spacing;
        for (int count = 0; count < raw; count++)
        {
            // 基準を作成
            var obj = new GameObject("HoriLayout");
            var hori = obj.AddComponent<HorizontalLayoutGroup>();
            // プロパティの変更
            hori.childControlHeight = false;
            hori.childControlWidth = false;
            hori.spacing = spacing;
            // 親を設定
            obj.transform.parent = verticalLayout.transform;

            for (int rowCount = 0; rowCount < column; rowCount++)
            {
                Instantiate(tile, obj.transform);
            }
        }
    }
}
