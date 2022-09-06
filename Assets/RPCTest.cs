using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RPCTest : MonoBehaviour
{
    private PhotonView _photonView;

    [SerializeField]
    private TestObject _go;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    // RPCÇåƒÇ‘
    public void OnClick()
    {
        _photonView.RPC("Test", RpcTarget.All, _go);
    }

    // åƒÇŒÇÍÇÈèàóù
    [PunRPC]
    public void Test(TestObject go)
    {
        if (go == _go)
        {
            Debug.Log("True" + go._num);
            return;
        }

        Debug.Log("False");
    }
}
