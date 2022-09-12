using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// �^�C���I�u�W�F�N�g
/// </summary>]
[RequireComponent(typeof(EventTrigger))]
public class Tile : MonoBehaviour
{
    public int ID { get; set; }

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }
}