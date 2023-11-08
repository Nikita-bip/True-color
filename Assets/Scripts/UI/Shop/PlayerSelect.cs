using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Button _choosenButton;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _selectedText;
    [SerializeField] private TextMeshProUGUI _choosenText;

    private GameObject[] _characters;
    private int _index;
    private int _money;

    private void Start()
    {
        _index = PlayerPrefs.GetInt("CharacterSelected");
        _money = PlayerPrefs.GetInt(Constantes.StrCountMoney);
        _characters = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _characters[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject character in _characters)
        {
            character.SetActive(false);
        }

        if (_characters[_index])
        {
            _characters[_index].SetActive(true);
        }
    }

    public void SelectLeft()
    {
        _characters[_index].SetActive(false);
        _index--;

        if (_index < 0)
        {
            _index = _characters.Length - 1;
        }

        _characters[_index].SetActive(true);
    }

    public void SelectRight()
    {
        _characters[_index].SetActive(false);
        _index++;

        if (_index == _characters.Length)
        {
            _index = 0;
        }

        _characters[_index].SetActive(true);
    }

    public void BuyButtonAction()
    {
        if (_buyButton.interactable)
        {
            if (_money > int.Parse(_priceText.text))
            {
                _money -= int.Parse(_priceText.text);
                _moneyText.text = _money.ToString();
                PlayerPrefs.SetInt(Constantes.StrCountMoney, _money);
                _choosenButton.gameObject.SetActive(true);
                _priceText.gameObject.SetActive(false);
                Save();
            }
        }
    }

    public void ChoosenButtonAction()
    {
        _choosenButton.interactable = false;
        _choosenText.gameObject.SetActive(false);
        _selectedText.gameObject.SetActive(true);
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }
}