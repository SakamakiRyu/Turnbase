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
        public int ID;
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
            ID = 9,
            Name = image.name
        };
        var sendDate = JsonUtility.ToJson(date);
        _photonView.RPC(nameof(SendDate), RpcTarget.Others, sendDate);
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
    public void SendDate(string sendDate)
    {
        var date = JsonUtility.FromJson<SendDatePack>(sendDate);
        Debug.Log(date.Name + " " + date.ID);
    }
}
