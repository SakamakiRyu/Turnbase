using UnityEngine;

/// <summary>
/// �^�C���N���X
/// </summary>
public class TileDate : MonoBehaviour
{
    [SerializeField]
    private int _number;

    public void SetNumber(int number)
    {
        _number = number;
    }
}
