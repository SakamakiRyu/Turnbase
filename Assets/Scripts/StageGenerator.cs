using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージを作成するクラス
/// </summary>
public class StageGenerator : MonoBehaviour, IStageGenerator
{
    // ステージが作成済みか
    public bool IsCreated { get; set; } = false;

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
