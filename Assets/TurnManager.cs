using UnityEngine;

using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
    [SerializeField]
    private PunTurnManager _turnManager;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _turnManager.BeginTurn();
        }
    }

    // �e�v���C���[�̍s�����I��������ɌĂ΂��
    public void OnPlayerFinished(Player player, int turn, object move)
    {
    }

    // SendMessage�͌Ă΂ꂽ���ɌĂ΂��
    public void OnPlayerMove(Player player, int turn, object move)
    {
    }

    // �^�[�����n�܂������ɌĂ΂��
    public void OnTurnBegins(int turn)
    {
    }

    // �^�[�����I���������ɌĂ΂��
    public void OnTurnCompleted(int turn)
    {
    }

    // ���Ԑ؂�ŌĂ΂��
    public void OnTurnTimeEnds(int turn)
    {
    }
}
