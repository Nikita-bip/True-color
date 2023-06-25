using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;
using System;

public class PlayerData : MonoBehaviour, IDisposable
{
    private const string LevelKey = "Level";
    private const string MusicKey = "Music";
    private const string SFXKey = "SFX";
    private const string LocalizationKey = "Localization";
    private const string SelectedCarKey = "Car";
    private const string ConditionsForCharactersKey = "Conditions";

    private const int MoneyDefault = 100;
    private const int LevelDefault = 1;
    private const bool MusicDefault = true;
    private const bool SFXDefault = true;
    private const int SelectedCharacterDefault = 0;

    public static PlayerData Instance { get; private set; }

    private int _money;
    private int _level;
    private bool _isMusicOn;
    private bool _isSFXOn;
    private string _currentLocalization;
    private int _selectedCharacter;
    private Dictionary<PlayerCharacterName, int> _conditionsForCharacters = new Dictionary<PlayerCharacterName, int>();

    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            if (value < 0 && value > Int32.MaxValue)
                throw new RankException("Incorrect value of money");

            _money = value;
            MoneyChanged?.Invoke(_money);
            SaveMoney();
        }
    }

    public int Level => _level;

    public bool IsMusicOn
    {
        get
        {
            return _isMusicOn;
        }
        set
        {
            _isMusicOn = value;
            MusicStatusChange?.Invoke();
            SaveData();
        }
    }

    public bool IsSFXOn
    {
        get
        {
            return _isSFXOn;
        }
        set
        {
            _isSFXOn = value;
            SFXStatusChange?.Invoke();
            SaveData();
        }
    }

    public string CurrentLocalization
    {
        get
        {
            return _currentLocalization;
        }
        set
        {
            _currentLocalization = value;
            LanguageChange?.Invoke(_currentLocalization);
        }
    }

    public int SelectedCgaracter
    {
        get
        {
            return _selectedCharacter;
        }
        set
        {
            if (0 <= value)
                _selectedCharacter = value;
            else
                throw new RankException("Incorrect value of car type!");
        }
    }

    public IReadOnlyDictionary<PlayerCharacterName, int> ConditionsForCharacters => _conditionsForCharacters;

    public bool IsDataLoaded { get; private set; } = false;

    public event UnityAction MusicStatusChange;
    public event UnityAction SFXStatusChange;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<string> LanguageChange;

    public void Init()
    {
        if (Instance == null)
            Instance = this;

        LoadData();
    }

    public void Dispose()
    {
        SaveData();
    }

    public void ChangeConditionForCharacter(PlayerCharacterName type)
    {
        if (_conditionsForCharacters[type] - 1 < 0)
            throw new RankException("Incorrect value for the car condition");

        _conditionsForCharacters[type]--;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(Constantes.StrCountMoney, _money);
        PlayerPrefs.SetInt(LevelKey, _level);
        PlayerPrefs.SetInt(MusicKey, Convert.ToInt32(_isMusicOn));
        PlayerPrefs.SetInt(SFXKey, Convert.ToInt32(_isSFXOn));
        PlayerPrefs.SetString(LocalizationKey, _currentLocalization);
        PlayerPrefs.SetInt(SelectedCarKey, _selectedCharacter);
        PlayerPrefs.SetString(ConditionsForCharactersKey, ConvertConditionsForCharacterToString());

        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        _money = PlayerPrefs.HasKey(Constantes.StrCountMoney) ? PlayerPrefs.GetInt(Constantes.StrCountMoney) : MoneyDefault;
        //_money = 12_345;
        _level = PlayerPrefs.HasKey(LevelKey) ? PlayerPrefs.GetInt(LevelKey) : LevelDefault;
        _isMusicOn = PlayerPrefs.HasKey(MusicKey) ? Convert.ToBoolean(PlayerPrefs.GetInt(MusicKey)) : MusicDefault;
        _isSFXOn = PlayerPrefs.HasKey(SFXKey) ? Convert.ToBoolean(PlayerPrefs.GetInt(SFXKey)) : SFXDefault;
        _currentLocalization = PlayerPrefs.HasKey(LocalizationKey) ? PlayerPrefs.GetString(LocalizationKey) : "English";
        _selectedCharacter = PlayerPrefs.HasKey(SelectedCarKey) ? PlayerPrefs.GetInt(SelectedCarKey) : SelectedCharacterDefault;
        LoadConditionsForCharacters();

        IsDataLoaded = true;
    }

    private void LoadConditionsForCharacters()
    {
        if (PlayerPrefs.HasKey(ConditionsForCharactersKey) && PlayerPrefs.GetString(ConditionsForCharactersKey).Length > 0)
        {
            string[] encryptedDate = PlayerPrefs.GetString(ConditionsForCharactersKey).Split(';');
            foreach (var date in encryptedDate)
            {
                string[] pairOfValues = date.Split(',');

                int key = int.Parse(pairOfValues[0]);
                int value = int.Parse(pairOfValues[1]);

                _conditionsForCharacters[(PlayerCharacterName)key] = value;
            }
        }
        else
        {
            LoadConditionsFromPriceList();
        }
    }

    private void LoadConditionsFromPriceList()
    {
        var priceList = Resources.Load<PriceList>("PriceList");

        foreach (var item in priceList.Prices)
        {
            PlayerCharacterName characterType = item.PlayerCharacterName;
            int conditions = item.IsBuyForAd ? item.Cost : 1;
            _conditionsForCharacters[characterType] = conditions;
        }

        _conditionsForCharacters[PlayerCharacterName.Base] = 0;
    }

    private string ConvertConditionsForCharacterToString()
    {
        var data = new List<string>();

        foreach (var conditions in _conditionsForCharacters)
        {
            data.Add($"{(int)conditions.Key},{conditions.Value}");
        }

        string result = String.Join(';', data.ToArray());
        return result;
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt(Constantes.StrCountMoney, _money);
        PlayerPrefs.Save();
    }


#if UNITY_EDITOR
    [ContextMenu("Reset Data")]
    private void ResetData()
    {
        _money = MoneyDefault;
        _level = LevelDefault;
        _isMusicOn = MusicDefault;
        _isSFXOn = SFXDefault;
        _currentLocalization = "English";
        _selectedCharacter = SelectedCharacterDefault;
        LoadConditionsFromPriceList();

        SaveData();
    }
#endif
}