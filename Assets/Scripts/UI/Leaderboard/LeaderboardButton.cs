using Agava.YandexGames;
using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class LeaderboardButton : MonoBehaviour
    {
        [SerializeField] private LoginPanel _logInPanel;
        [SerializeField] private LoginAcceptButton _loginAcceptButton;

        public void OnClick()
        {
            OpenLoginPanel();
        }

        private void OpenLoginPanel()
        {
            if (PlayerAccount.IsAuthorized == false)
            {
                _logInPanel.gameObject.SetActive(true);
            }
            else
            {
                _loginAcceptButton.OpenLeaderboard();
            }
        }
    }
}