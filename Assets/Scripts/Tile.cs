using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�W�̃^�C���N���X(�^�C���𕡐����ׂăX�e�[�W���쐬����)
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