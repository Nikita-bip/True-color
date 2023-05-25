using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Shop : MonoBehaviour
{
    [SerializeField] private SettingsButton _settingsButton;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private ShopButton _shopButton;
    [SerializeField] private Cube _cube;
    [SerializeField] private LeaderboardButton _leaderboardButton;
    [SerializeField] private TMP_Text _countOfMoney;
    [SerializeField] private int _scinIndex = 0;
    [SerializeField] private GameObject[] _scin;
    [SerializeField] private ScinBlueprint[] _scins;
    [SerializeField] private Button _buyButton;

    public static int Money;

    private void Start()
    {
        Money = PlayerPrefs.GetInt(Constantes.StrCountMoney, Money);

        foreach (ScinBlueprint scin in _scins)
        {
            if (scin.Price == 0)
                scin.IsUnlocked = true;
            else
                scin.IsUnlocked = PlayerPrefs.GetInt(scin.name, 0) == 0 ? false : true;
        }
        _scinIndex = PlayerPrefs.GetInt(Constantes.StrSelectedScin, 0);

        foreach (GameObject scin in _scin)
            scin.SetActive(false);


        _scin[_scinIndex].SetActive(true);
    }

    private void Update()
    {
        UpdateUI();
    }

    private void OnEnable()
    {
        _settingsButton.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        _cube.gameObject.SetActive(false);
        _leaderboardButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _settingsButton.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(true);
        _shopButton.gameObject.SetActive(true);
        _cube.gameObject.SetActive(true);
        _leaderboardButton.gameObject.SetActive(true);
    }

    public void ChangeNext()
    {
        _scin[_scinIndex].SetActive(false);

        _scinIndex++;

        if (_scinIndex == _scin.Length)
            _scinIndex = 0;

        _scin[_scinIndex].SetActive(true);
        ScinBlueprint scin = _scins[_scinIndex];

        if (!scin.IsUnlocked)
            return;

        PlayerPrefs.SetInt(Constantes.StrSelectedScin, _scinIndex);
    }

    public void ChangePrewious()
    {
        _scin[_scinIndex].SetActive(false);

        _scinIndex--;

        if (_scinIndex == -1)
            _scinIndex = _scin.Length - 1;

        _scin[_scinIndex].SetActive(true);
        ScinBlueprint scin = _scins[_scinIndex];

        if (!scin.IsUnlocked)
            return;

        PlayerPrefs.SetInt(Constantes.StrSelectedScin, _scinIndex);
    }

    public void UnLockScin()
    {
        ScinBlueprint scin = _scins[_scinIndex];

        PlayerPrefs.SetInt(scin.name, 1);
        PlayerPrefs.SetInt(Constantes.StrSelectedScin, _scinIndex);
        scin.IsUnlocked = true;
        Money -= scin.Price;
        PlayerPrefs.SetInt(Constantes.StrCountMoney, Money);
    }

    private void UpdateUI()
    {
        //ScinBlueprint scin = _scins[_scinIndex];
        _countOfMoney.text = PlayerPrefs.GetInt(Constantes.StrCountMoney).ToString();

        //if (scin.isUnlocked)
        //{
        //    _buyButton.gameObject.SetActive(false);

        //}
        //else
        //{
        //    _buyButton.gameObject.SetActive(true);
        //    _buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "" + scin.price;

        //    if (PlayerPrefs.GetInt(Constantes.StrCountMoney, 0) > scin.price)
        //    {
        //        _buyButton.interactable = true;

        //    }
        //    else
        //    {
        //        _buyButton.interactable = false;
        //    }
        //}
    }
}
