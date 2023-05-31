using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class FinishPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _countOfMoneyText;
    [SerializeField] private AudioSource _myFX;
    [SerializeField] private AudioClip _win;
    [SerializeField] private Movement _movement;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _switcher;
    [SerializeField] private Finish _finish;

    private Animator _animator;
    private static int _countOfMoney;
    public static int CountLevel { get; private set; }

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
        _movement.enabled = false;
        _joystick.SetActive(false);
        _switcher.SetActive(false);
        GenerateCountOfMoney();
        _myFX.PlayOneShot(_win);
        SaveScore();
    }

    public static void SaveScore()
    {
        CountLevel++;

        PlayerPrefs.SetInt(Constantes.StrCountLevel, PlayerPrefs.GetInt(Constantes.StrCountLevel) + CountLevel);
        PlayerPrefs.SetInt(Constantes.StrCountMoney, PlayerPrefs.GetInt(Constantes.StrCountMoney) + _countOfMoney);

        PlayerPrefs.Save();

        Leaderboard.AddPlayer(CountLevel);
    }
}
