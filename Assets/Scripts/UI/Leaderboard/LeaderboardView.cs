using System.Collections.Generic;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private LeaderboardPlayerView _leaderboardPlayerView;
    [SerializeField] private CloseButton _closeButton;
    [SerializeField] private SettingsButton _settingsButton;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private LeaderboardButton _leaderboardButton;
    [SerializeField] private ShopButton _shopButton;
    [SerializeField] private Cube _cube;
    [SerializeField] private LoginPanel _loginPanel;

    private readonly List<LeaderboardPlayerView> _spawnedPlayerViews = new();

    private void OnEnable()
    {
        _closeButton.gameObject.SetActive(true);
        _settingsButton.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _leaderboardButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        _cube.gameObject.SetActive(false);

        _loginPanel.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _closeButton.gameObject.SetActive(false);
        _settingsButton.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(true);
        _leaderboardButton.gameObject.SetActive(true);
        _shopButton.gameObject.SetActive(true);
        _cube.gameObject.SetActive(true);
    }

    public void Create(List<LeaderboardPlayer> players)
    {
        Clear();

        foreach (var player in players)
        {
            var leaderboardPlayerView = Instantiate(_leaderboardPlayerView, transform);
            leaderboardPlayerView.Init(player.Name, player.Score.ToString());

            _spawnedPlayerViews.Add(leaderboardPlayerView);
        }
    }

    private void Clear()
    {
        foreach (var playerView in _spawnedPlayerViews)
            Destroy(playerView.gameObject);

        _spawnedPlayerViews.Clear();
    }
}
