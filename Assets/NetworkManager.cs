using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// �l�b�g���[�N�}�l�[�W���[
/// </summary>
public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        Connect("1.0");
    }

    // �T�[�o�[�ڑ�
    private void Connect(string gameVersion)
    {
        StartCoroutine(ConnectAsync(gameVersion));
    }

    // �ڑ�
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
    // �ڑ��Ɏ��s�������ɌĂ΂��
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("�ؒf���܂���");
    }

    // �}�X�^�[�T�[�o�[�ɐڑ����ꂽ���ɌĂ΂��
    public override void OnConnectedToMaster()
    {
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
    }

    // Room�ɎQ�������Ƃ��ɌĂ΂�鏈��(����)
    public override void OnJoinedRoom()
    {
    }

    // ���̃v���C���[�������̋���Room�ɎQ���������ɌĂ΂��
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        CloseRoom();
    }

    // ���̃v���C���[�������̋���Room��ޏo�������ɌĂ΂��
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        OpenRoom();
    }

    // ���r�[�ɎQ�������Ƃ��ɌĂ΂��
    public override void OnJoinedLobby()
    {
        if (PhotonNetwork.IsConnected)
        {
            // �����ɎQ��
            PhotonNetwork.JoinRandomRoom();
        }
    }

    // �����������������ɌĂ΂��
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
    #endregion

    // ���������J����(���̐l���Q���ł���悤�ɂ���)
    private void OpenRoom()
    {
        PhotonNetwork.CurrentRoom.IsOpen = true;
    }

    // ���������(���̐l���Q���o���Ȃ��悤�ɂ���)
    private void CloseRoom()
    {
        // ���������
        PhotonNetwork.CurrentRoom.IsOpen = false;
    }

    // ���r�[�쐬
    private void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            RoomOptions roomOptions = new()
            {
                // �N�ł��Q���\��
                IsVisible = true,
                // �ő�l��
                MaxPlayers = 2
            };
            // ���[���̍쐬
            PhotonNetwork.CreateRoom("Default", roomOptions);
        }
    }
}
