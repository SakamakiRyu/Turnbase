using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�W�쐬�I�u�W�F�N�g
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
    /// �X�e�[�W���쐬
    /// </summary>
    private void CreateStage(VerticalLayoutGroup verticalLayout, int spacing, Tile tile, int column, int raw)
    {
        // �Ԋu��ݒ�
        verticalLayout.spacing = spacing;
        for (int count = 0; count < raw; count++)
        {
            // ����쐬
            var obj = new GameObject("HoriLayout");
            var hori = obj.AddComponent<HorizontalLayoutGroup>();
            // �v���p�e�B�̕ύX
            hori.childControlHeight = false;
            hori.childControlWidth = false;
            hori.spacing = spacing;
            // �e��ݒ�
            obj.transform.parent = verticalLayout.transform;

            for (int rowCount = 0; rowCount < column; rowCount++)
            {
                Instantiate(tile, obj.transform);
            }
        }
    }
}
