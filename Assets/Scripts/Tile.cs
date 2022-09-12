using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// タイルオブジェクト
/// </summary>]
[RequireComponent(typeof(EventTrigger))]
public class Tile : MonoBehaviour
{
    [SerializeField]
    private int _id;

    public int ID => _id;

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