using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private LeaderboardView _leaderboardView;

    private const string LeaderboardName = "TrueColor";
    private const int MinPlayersCount = 1;
    private const int MaxPlayersCount = 5;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

    public static void AddPlayer(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

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
            return;

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
        {
            var results = result.entries.Length;
            results = Mathf.Clamp(results, MinPlayersCount, MaxPlayersCount);
            for (var i = 0; i < results; i++)
            {
                var score = result.entries[i].score;
                var playerName = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(playerName))
                    playerName = AnonimLanguage.GetAnonymous(PlayerPrefs.GetString(Constantes.Language));

                _leaderboardPlayers.Add(new LeaderboardPlayer(playerName, score));
            }
            _leaderboardView.Create(_leaderboardPlayers);
        });
        PlayerPrefs.Save();
    }
}