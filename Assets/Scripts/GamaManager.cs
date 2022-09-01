using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームマネージャークラス
/// </summary>
public class GamaManager : MonoBehaviour
{
    [SerializeField]
    private Tile _tile;

    [SerializeField]
    private int _x;

    [SerializeField]
    private int _y;

    [SerializeField]
    private int _verticalSpacing;

    [SerializeField]
    private int _horizontalSpacing;

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        if (ServiceLocator<IStageCreater>.IsValid)
        {
            ServiceLocator<IStageCreater>.Instance.CreateStageRequest(_tile, _verticalSpacing, _horizontalSpacing, _x, _y);
        }
    }
}
