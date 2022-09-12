using Photon.Pun;
using System.Linq;
using UnityEngine;

using Photon.Realtime;

[RequireComponent(typeof(PhotonView))]
public class EventTest : MonoBehaviour
{
    // PRC���g����
    private PhotonView _photonView;
    // �^�C�����X�g
    private Tile[] _tiles;

    [System.Serializable]
    public struct SendDates
    {
        public int ActorNumber;
        public int ID;
    }

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        _tiles = FindObjectsOfType<Tile>();
    }

    // �^�C�����N���b�N���ꂽ���ɌĂ΂��
    public void OnPointerClick(Tile tile)
    {
        var sendPack = new
        {
            ActorNumber = PhotonNetwork.LocalPlayer.ActorNumber,
            ID = tile.ID
        };
        var json = JsonUtility.ToJson(sendPack);
        _photonView.RPC(nameof(SendDate), RpcTarget.All, json);
    }

    [PunRPC]
    public void SendDate(string json)
    {
        // json���猳�̃f�[�^�ɖ߂�
        var date = JsonUtility.FromJson<SendDates>(json);
        // �����Ă����^�C�����Q�Ƃ���
        var targetTile = _tiles.Where(x => x.ID == date.ID).First(x => x.GetComponent<Tile>());

        if (date.ActorNumber == 1)
        {
            targetTile.SetColor(Color.red);
        }
        else
        {
            targetTile.SetColor(Color.blue);
        }
    }
}
