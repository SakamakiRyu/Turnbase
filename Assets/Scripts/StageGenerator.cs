using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�W���쐬����N���X
/// </summary>
public class StageGenerator : MonoBehaviour, IStageGenerator
{
    // �X�e�[�W���쐬�ς݂�
    public bool IsCreated { get; set; } = false;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        if (!ServiceLocator<IStageGenerator>.IsValid)
        {
            ServiceLocator<IStageGenerator>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<IStageGenerator>.IsValid)
        {
            ServiceLocator<IStageGenerator>.UnRegist(this);
        }
    }
}
