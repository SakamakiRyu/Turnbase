using UnityEngine;

using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

[RequireComponent(typeof(PunTurnManager))]
public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
    private PunTurnManager _turnManager;

    private void Awake()
    {
        TryGetComponent(out _turnManager);
        // nullだったら追加する
        if (!_turnManager)
        {
            _turnManager = gameObject.AddComponent<PunTurnManager>();
        }
    }

    private void Start()
    {
        StartGame();
    }

    // ゲームをスタートする
    private void StartGame()
    {
        // マスタークライアントがゲームをスタートする
        if (PhotonNetwork.IsMasterClient)
        {
            _turnManager.BeginTurn();
        }
    }

    // 各プレイヤーの行動が終わった時に呼ばれる
    public void OnPlayerFinished(Player player, int turn, object move)
    {
    }

    // SendMessageは呼ばれた時に呼ばれる
    public void OnPlayerMove(Player player, int turn, object move)
    {
    }

    // ターンが始まった時に呼ばれる
    public void OnTurnBegins(int turn)
    {
    }

    // ターンが終了した時に呼ばれる
    public void OnTurnCompleted(int turn)
    {
    }

    // 時間切れで呼ばれる
    public void OnTurnTimeEnds(int turn)
    {
    }
}
