using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�W���쐬����N���X
/// </summary>
public class StageGenerator : MonoBehaviour,IStageCreater
{
    // �X�e�[�W���쐬�ς݂�
    public bool IsCreated { get; set; } = false;

    private void Awake()
    {

    }

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

    public bool CreateStageRequest(Tile tile)
    {
        throw new System.NotImplementedException();
    }
}
