using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージのタイルクラス(タイルを複数並べてステージを作成する)
/// </summary>
public class Tile : MonoBehaviour
{
    [SerializeField]
    private Sprite _sprite;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

        if (!_renderer)
        {
            _renderer.sprite = _sprite;
        }
    }
}