using UnityEngine;

[CreateAssetMenu(fileName = "GameSetting")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private int _spacing;

    public int Spacing => _spacing;
}
