using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class EventTest : MonoBehaviour
{
    // PRC‚ðŽg‚¤ˆ×
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    public void OnPointerClick(Image image)
    {
        _photonView.RPC(nameof(SendDate), RpcTarget.Others, image.name);
    }

    public void OnPointerEnter(Image image)
    {
        image.color = Color.blue;
    }

    public void OnPointerExit(Image image)
    {
        image.color = Color.white;
    }

    [PunRPC]
    public void SendDate(string name)
    {
        Debug.Log(name);
    }
}
