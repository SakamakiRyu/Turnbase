using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class RPCTest : MonoBehaviour
{
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    // RPCÇåƒÇ‘
    public void OnClick()
    {
        var t = new TestPlayer
        {
            Name = "AAA",
            ID = 123
        };
        var json = JsonUtility.ToJson(t);
        _photonView.RPC(nameof(Test), RpcTarget.Others, json);
    }

    // åƒÇŒÇÍÇÈèàóù
    [PunRPC]
    public void Test(string json)
    {
        var date = JsonUtility.FromJson<TestPlayer>(json);
        Debug.Log(date.Name + " : " + date.ID.ToString());
    }
}

[System.Serializable]
public class TestPlayer
{
    public string Name;
    public int ID;
}
