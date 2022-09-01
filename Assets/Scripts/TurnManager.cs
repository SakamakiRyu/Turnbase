using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int _currentTurn = 0;

    public void AddTurnCount()
    {
        _currentTurn++;
    }
}
