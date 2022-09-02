using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージを作成するクラス
/// </summary>
public class StageGenerator : MonoBehaviour,IStageCreater
{
    // ステージが作成済みか
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
