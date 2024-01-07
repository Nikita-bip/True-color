using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class LeaderboardPlayer : MonoBehaviour
    {
        public LeaderboardPlayer(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; private set; }

        public int Score { get; private set; }
    }
}