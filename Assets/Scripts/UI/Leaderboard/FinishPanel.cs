using Assets.Scripts.Ad;
using Assets.Scripts.UI.UIShop;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    [RequireComponent(typeof(Animator))]
    public class FinishPanel : MonoBehaviour
    {

        private static int CountLevel;

        [SerializeField] private TMP_Text _countOfMoneyText;
        [SerializeField] private AudioSource _myFX;
        [SerializeField] private AudioClip _win;
        [SerializeField] private Movement[] _movements;
        [SerializeField] private GameObject _joystick;
        [SerializeField] private GameObject _switcher;
        [SerializeField] private GameObject _color;
        [SerializeField] private GameObject _timer;
        [SerializeField] private InterstitialAdShower _interstitialAdShower;

        private Animator _animator;
        private int _countOfMoney;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void GenerateCountOfMoney()
        {
            _countOfMoney = Random.Range(5, 16);
            _countOfMoneyText.text = _countOfMoney.ToString();
        }

        private void OnEnable()
        {
            Finish._onFinished += OpenPanel;
            _joystick.SetActive(false);
            _switcher.SetActive(false);
            _color.SetActive(false);
            _timer.SetActive(false);
            GenerateCountOfMoney();
            _myFX.PlayOneShot(_win);
            SaveScore();
        }

        private void OnDisable()
        {
            Finish._onFinished -= OpenPanel;
        }

        private void OpenPanel()
        {
            _animator.SetBool(Constants.StrFinish, true);
        }

        private void SaveScore()
        {
            CountLevel++;
            PlayerData.Instance.Money += _countOfMoney;
            PlayerData.Instance.Level += 1;
            PlayerPrefs.SetInt(Constants.StrCountLevel, PlayerPrefs.GetInt(Constants.StrCountLevel) + CountLevel);
            Leaderboard.AddPlayer(PlayerData.Instance.Level);
            PlayerPrefs.Save();
        }
    }
}