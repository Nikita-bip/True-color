using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Setting : MonoBehaviour
{
    [SerializeField] private SettingsButton _settingsButton;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private LeaderboardButton _leaderboardButton;
    [SerializeField] private ShopButton _shopButton;
    [SerializeField] private Cube _cube;
    [SerializeField] private CloseButton _closeButton;

    private void OnEnable()
    {
        _settingsButton.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _leaderboardButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        _cube.gameObject.SetActive(false);
        _closeButton.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _settingsButton.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(true);
        _leaderboardButton.gameObject.SetActive(true);
        _shopButton.gameObject.SetActive(true);
        _cube.gameObject.SetActive(true);
        _closeButton.gameObject.SetActive(false);
    }
}
