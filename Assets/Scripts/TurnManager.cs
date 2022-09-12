using UnityEngine;

using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

[RequireComponent(typeof(PunTurnManager))]
public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
    // Photon�̃^�[���Ǘ��N���X
    private PunTurnManager _turnManager;

    private void Awake()
    {
        TryGetComponent(out _turnManager);
        // null��������ǉ�����
        if (!_turnManager)
        {
            _turnManager = gameObject.AddComponent<PunTurnManager>();
        }
    }

    private void Start()
    {
        StartGame();
    }

    // �Q�[�����X�^�[�g����
    private void StartGame()
    {
        // �}�X�^�[�N���C�A���g���Q�[�����X�^�[�g����
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
