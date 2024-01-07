using Assets.Scripts.UI.Buttons;
using Assets.Scripts.UI.Leaderboard;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    [RequireComponent(typeof(Animator))]
    public class Setting : MonoBehaviour
    {
        private const string _openAnimation = nameof(OpenAnimation);

        [SerializeField] private SettingsButton _settingsButton;
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private LeaderboardButton _leaderboardButton;
        [SerializeField] private ShopButton _shopButton;
        [SerializeField] private Cube _cube;
        [SerializeField] private CloseButton _closeButton;
        [SerializeField] private GameObject _label;
        [SerializeField] private Animator _labelSettingAnimator;
        [SerializeField] private Animator _closeSettingAnimator;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _settingsButton.gameObject.SetActive(false);
            _playButton.gameObject.SetActive(false);
            _leaderboardButton.gameObject.SetActive(false);
            _shopButton.gameObject.SetActive(false);
            _cube.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(true);
            _label.gameObject.SetActive(true);

            Invoke(_openAnimation, 0.1f);
        }

        private void OnDisable()
        {
            _settingsButton.gameObject.SetActive(true);
            _playButton.gameObject.SetActive(true);
            _leaderboardButton.gameObject.SetActive(true);
            _shopButton.gameObject.SetActive(true);
            _cube.gameObject.SetActive(true);
            _closeButton.gameObject.SetActive(false);
            _label.gameObject.SetActive(false);
        }

        private void OpenAnimation()
        {
            _animator.SetBool("Open", true);
            _labelSettingAnimator.SetBool("Open", true);
            _closeSettingAnimator.SetBool("Open", true);
        }
    }
}