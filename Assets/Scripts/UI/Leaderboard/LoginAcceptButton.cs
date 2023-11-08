using Agava.YandexGames;
using UnityEngine;

public class LoginAcceptButton : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private LeaderboardView _leaderboardView;

    public void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            return;

        _leaderboardView.gameObject.SetActive(true);
        _leaderboard.Fill();
    }

    public void OnClick()
    {
        OpenLeaderboard();
    }
}