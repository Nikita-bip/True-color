using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class Leaderboard : MonoBehaviour
    {
        private const string LeaderboardName = "TrueColor";
        private const int MinPlayersCount = 1;
        private const int MaxPlayersCount = 5;

        [SerializeField] private LeaderboardView _leaderboardView;

        private readonly List<LeaderboardPlayer> _leaderboardPlayers = new ();

        public static void AddPlayer(int score)
        {
            if (PlayerAccount.IsAuthorized == false)
            {
                return;
            }

            Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, _ =>
            {
                Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
            });
            PlayerPrefs.Save();
        }

        public void Fill()
        {
            _leaderboardPlayers.Clear();

            if (PlayerAccount.IsAuthorized == false)
            {
                return;
            }

            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
            {
                int results = result.entries.Length;
                results = Mathf.Clamp(results, MinPlayersCount, MaxPlayersCount);

                for (var i = 0; i < results; i++)
                {
                    int score = result.entries[i].score;
                    string playerName = result.entries[i].player.publicName;

                    if (string.IsNullOrEmpty(playerName))
                    {
                        playerName = AnonimLanguage.GetAnonymous(PlayerPrefs.GetString(Constants.Language));
                    }

                    _leaderboardPlayers.Add(new LeaderboardPlayer(playerName, score));
                }

                _leaderboardView.Create(_leaderboardPlayers);
            });
            PlayerPrefs.Save();
        }
    }
}