using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private Tile[] _tiles;

    private void Start()
    {
        SetNumber(_tiles);
    }

    // ID��ݒ肷��
    private void SetNumber(Tile[] tiles)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].ID = i;
        }
    }
}
