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
        var id = tile.ID;
        var actNum = PhotonNetwork.LocalPlayer.ActorNumber;
        _photonView.RPC(nameof(SendDate), RpcTarget.All,actNum, id);
    }

    [PunRPC]
    public void SendDate(int actorNumber,int ID)
    {
        var targetTile = _tiles.Where(x => x.ID == ID).First(x => x.GetComponent<Tile>());

        if (actorNumber == 1)
        {
            targetTile.SetColor(Color.red);
        }
        else
        {
            targetTile.SetColor(Color.blue);
        }
    }
}
