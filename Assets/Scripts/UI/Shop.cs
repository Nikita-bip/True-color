using Assets.Scripts.UI.Buttons;
using Assets.Scripts.UI.Leaderboard;
using Assets.Scripts.UI.MainMenu;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private SettingsButton _settingsButton;
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private Language _languageButton;
        [SerializeField] private LeaderboardButton _leaderboardButton;
        [SerializeField] private ShopButton _shopButton;
        [SerializeField] private Cube _cube;
        [SerializeField] private TMP_Text _countOfMoney;

        private void OnEnable()
        {
            _settingsButton.gameObject.SetActive(false);
            _playButton.gameObject.SetActive(false);
            _languageButton.gameObject.SetActive(false);
            _leaderboardButton.gameObject.SetActive(false);
            _shopButton.gameObject.SetActive(false);
            _cube.gameObject.SetActive(false);

            _countOfMoney.text = PlayerPrefs.GetInt(Constants.StrCountMoney).ToString();
        }

        private void OnDisable()
        {
            _settingsButton.gameObject.SetActive(true);
            _playButton.gameObject.SetActive(true);
            _languageButton.gameObject.SetActive(true);
            _leaderboardButton.gameObject.SetActive(true);
            _shopButton.gameObject.SetActive(true);
            _cube.gameObject.SetActive(true);
        }
    }
}