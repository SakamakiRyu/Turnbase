using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
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
