using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class FinishPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _countOfMoneyText;
    [SerializeField] private AudioSource _myFX;
    [SerializeField] private AudioClip _win;
    [SerializeField] private Movement[] _movements;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _switcher;
    [SerializeField] private GameObject _color;
    [SerializeField] private Finish _finish;
    [SerializeField] private GameObject _timer;
    [SerializeField] private InterstitialAdShower _interstitialAdShower;

    private Animator _animator;
    private int _countOfMoney;
    private static int CountLevel;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_finish.IsFinished == true)
        {
            _animator.SetBool(Constantes.StrFinish, true);
        }
    }

    private void GenerateCountOfMoney()
    {
        _countOfMoney = Random.Range(5, 16);
        _countOfMoneyText.text = _countOfMoney.ToString();
    }

    private void OnEnable()
    {
        _joystick.SetActive(false);
        _switcher.SetActive(false);
        _color.SetActive(false);
        _timer.SetActive(false);
        GenerateCountOfMoney();
        _myFX.PlayOneShot(_win);
        SaveScore();
    }

    //private void OnDisable()
    //{
    //    _interstitialAdShower.Show();
    //}

    private void SaveScore()
    {
        CountLevel++;
        PlayerData.Instance.Money += _countOfMoney;
        PlayerData.Instance.Level += 1;
        PlayerPrefs.SetInt(Constantes.StrCountLevel, PlayerPrefs.GetInt(Constantes.StrCountLevel) + CountLevel);
        Leaderboard.AddPlayer(PlayerData.Instance.Level);
        PlayerPrefs.Save();
    }
}
