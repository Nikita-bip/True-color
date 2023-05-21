using UnityEngine.UI;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{
    [SerializeField] private SettingsButton _settingsButton;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private LeaderboardButton _leaderboardButton;
    [SerializeField] private ShopButton _shopButton;
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _settingsButton.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _leaderboardButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        _cube.gameObject.SetActive(false);
    }

    private void OnDisable()
    {        
        _settingsButton.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(true);
        _leaderboardButton.gameObject.SetActive(true);
        _shopButton.gameObject.SetActive(true);
        _cube.gameObject.SetActive(true);
    }
}
