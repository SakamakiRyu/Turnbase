using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// ネットワークマネージャー
/// </summary>
public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        Connect("1.0");
    }

    // サーバー接続
    private void Connect(string gameVersion)
    {
        StartCoroutine(ConnectAsync(gameVersion));
    }

    // 接続
    private IEnumerator ConnectAsync(string gameVersion)
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
            yield return null;
        }
        yield return null;
    }

    #region Photon Callbacks
    // 接続に失敗した時に呼ばれる
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("切断しました");
    }

    // マスターサーバーに接続された時に呼ばれる
    public override void OnConnectedToMaster()
    {
        // ロビーに参加
        PhotonNetwork.JoinLobby();
    }

    // Roomに参加したときに呼ばれる処理(自分)
    public override void OnJoinedRoom()
    {
    }

    // 他のプレイヤーが自分の居るRoomに参加した時に呼ばれる
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        CloseRoom();
    }

    // 他のプレイヤーが自分の居るRoomを退出した時に呼ばれる
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        OpenRoom();
    }

    // ロビーに参加したときに呼ばれる
    public override void OnJoinedLobby()
    {
        if (PhotonNetwork.IsConnected)
        {
            // 部屋に参加
            PhotonNetwork.JoinRandomRoom();
        }
    }

    // 部屋が無かった時に呼ばれる
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
    #endregion

    // 部屋を公開する(他の人が参加できるようにする)
    private void OpenRoom()
    {
        PhotonNetwork.CurrentRoom.IsOpen = true;
    }

    // 部屋を閉じる(他の人が参加出来ないようにする)
    private void CloseRoom()
    {
        // 部屋を閉じる
        PhotonNetwork.CurrentRoom.IsOpen = false;
    }

    // ロビー作成
    private void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            RoomOptions roomOptions = new()
            {
                // 誰でも参加可能か
                IsVisible = true,
                // 最大人数
                MaxPlayers = 2
            };
            // ルームの作成
            PhotonNetwork.CreateRoom("Default", roomOptions);
        }
    }
}
