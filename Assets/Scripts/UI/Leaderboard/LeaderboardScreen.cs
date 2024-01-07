using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class LeaderboardScreen : ScreenLeaderboard
    {
        [SerializeField] private GameObject _itemContainer;
        [SerializeField] private PlayerView _template;

        public void AddPlayerView(int playerNumber, string playerName, int playerScore, bool isUser = false)
        {
            var view = Instantiate(_template, _itemContainer.transform);
            view.Init(playerNumber, playerName, playerScore, isUser);
            view.Render();
        }
    }
}