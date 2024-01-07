using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class LeaderboardPlayerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _score;

        public void Init(string playerName, string score)
        {
            _playerName.text = playerName;
            _score.text = score;
        }
    }
}