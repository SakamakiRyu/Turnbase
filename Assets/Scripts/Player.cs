using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Piece[] _myPieces;

    private int MyNumber { get; set; }

    public void SetMyNumber(int num)
    {
        MyNumber = num;
    }
}
