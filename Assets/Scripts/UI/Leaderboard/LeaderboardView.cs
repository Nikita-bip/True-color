using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LeaderboardView : MonoBehaviour
{
    private const string _openAnimation = nameof(OpenAnimation);

    [SerializeField] private LeaderboardPlayerView _leaderboardPlayerView;
    [SerializeField] private CloseButton _closeButton;
    [SerializeField] private GameObject _label;
    [SerializeField] private SettingsButton _settingsButton;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private LeaderboardButton _leaderboardButton;
    [SerializeField] private ShopButton _shopButton;
    [SerializeField] private Cube _cube;
    [SerializeField] private LoginPanel _loginPanel;
    [SerializeField] private Animator _labelSettingAnimator;
    [SerializeField] private Animator _closeSettingAnimator;

    private Animator _animator;
    private readonly List<LeaderboardPlayerView> _spawnedPlayerViews = new ();

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _closeButton.gameObject.SetActive(true);
        _label.gameObject.SetActive(true);
        _settingsButton.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _leaderboardButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        _cube.gameObject.SetActive(false);
        _loginPanel.gameObject.SetActive(false);

        Invoke(_openAnimation, 0.1f);
    }

    private void OnDisable()
    {
        _closeButton.gameObject.SetActive(false);
        _label.gameObject.SetActive(false);
        _settingsButton.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(true);
        _leaderboardButton.gameObject.SetActive(true);
        _shopButton.gameObject.SetActive(true);
        _cube.gameObject.SetActive(true);
        PlayerPrefs.Save();
    }

    private void OpenAnimation()
    {
        _animator.SetBool("Open", true);
        _labelSettingAnimator.SetBool("Open", true);
        _closeSettingAnimator.SetBool("Open", true);
    }

    public void Create(List<LeaderboardPlayer> players)
    {
        Clear();

        foreach (LeaderboardPlayer player in players)
        {
            LeaderboardPlayerView leaderboardPlayerView = Instantiate(_leaderboardPlayerView, transform);
            leaderboardPlayerView.Init(player.Name, player.Score.ToString());

            _spawnedPlayerViews.Add(leaderboardPlayerView);
        }

        PlayerPrefs.Save();
    }

    private void Clear()
    {
        foreach (LeaderboardPlayerView playerView in _spawnedPlayerViews)
        {
            Destroy(playerView.gameObject);
        }

        _spawnedPlayerViews.Clear();
    }
}