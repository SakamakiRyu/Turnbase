using Photon.Pun;
using System.Linq;
using UnityEngine;

using Photon.Realtime;

[RequireComponent(typeof(PhotonView))]
public class EventTest : MonoBehaviour
{
    // PRCを使う為
    private PhotonView _photonView;
    // タイルリスト
    private Tile[] _tiles;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        _tiles = FindObjectsOfType<Tile>();
    }

    public void OnPointerClick(Tile tile)
    {
        var id = tile.ID;
        _photonView.RPC(nameof(SendDate), RpcTarget.All, id);
    }

    [PunRPC]
    public void SendDate(int ID)
    {
        var targetTile = _tiles.Where(x => x.ID == ID).First(x => x.GetComponent<Tile>());

        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            targetTile.SetColor(Color.red);
        }
        else
        {
            targetTile.SetColor(Color.blue);
        }
    }
}
