using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class EventTest : MonoBehaviour
{
    // PRC‚ðŽg‚¤ˆ×
    private PhotonView _photonView;

    [System.Serializable]
    private struct SendDatePack
    {
        public string Name;
    }

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    public void OnPointerClick(Image image)
    {
        var date = new SendDatePack
        {
            Name = image.name
        };
        var sendDate = JsonUtility.ToJson(date);
        _photonView.RPC(nameof(SendDate), RpcTarget.Others, sendDate);
    }

    [PunRPC]
    public void SendDate(string sendDate)
    {
        var date = JsonUtility.FromJson<SendDatePack>(sendDate);
        var sendedData = GameObject.Find(date.Name).GetComponent<Image>();
        sendedData.color = Color.red;
    }
}
