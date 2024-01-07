using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.UIShop
{
    public class PlayerData : MonoBehaviour
    {
        private const string SelectedCharacterKey = "Character";
        private const string ConditionsForCharactersKey = "Conditions";

        private const int SelectedCharacterDefault = 0;
        private int _money;
        private int _level;
        private int _selectedCharacter;
        private Dictionary<PlayerCharacterName, int> _conditionsForCharacters = new Dictionary<PlayerCharacterName, int>();

        public static PlayerData Instance { get; private set; }
        public bool IsDataLoaded { get; private set; } = false;

        public int Money
        {
            get
            {
                return _money;
            }

            set
            {
                if (value < 0 && value > int.MaxValue)
                {
                    throw new RankException("Incorrect value of money");
                }

                _money = value;
                MoneyChanged?.Invoke(_money);
                SaveMoney();
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
                SaveLevel();
            }
        }

        public int SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }

            set
            {
                if (value >= 0)
                {
                    _selectedCharacter = value;
                }
                else
                {
                    throw new RankException("Incorrect value of character type!");
                }
            }
        }

        public IReadOnlyDictionary<PlayerCharacterName, int> ConditionsForCharacters => _conditionsForCharacters;
        public event Action<int> MoneyChanged;

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            LoadData();
        }

        public void Dispose()
        {
            SaveData();
        }

        public void ChangeConditionForCharacter(PlayerCharacterName type)
        {
            if (_conditionsForCharacters[type] - 1 < 0)
            {
                throw new RankException("Incorrect value for the character condition");
            }

            _conditionsForCharacters[type]--;
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt(Constantes.StrCountMoney, _money);
            PlayerPrefs.SetInt(Constantes.StrCountLevel, _level);
            PlayerPrefs.SetInt(SelectedCharacterKey, _selectedCharacter);
            PlayerPrefs.SetString(ConditionsForCharactersKey, ConvertConditionsForCharacterToString());

            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            _money = PlayerPrefs.GetInt(Constantes.StrCountMoney);
            _level = PlayerPrefs.GetInt(Constantes.StrCountLevel);
            _selectedCharacter = PlayerPrefs.HasKey(SelectedCharacterKey) ? PlayerPrefs.GetInt(SelectedCharacterKey) : SelectedCharacterDefault;
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

            string result = string.Join(';', data.ToArray());
            return result;
        }

        private void SaveLevel()
        {
            PlayerPrefs.SetInt(Constantes.StrCountLevel, PlayerPrefs.GetInt(Constantes.StrCountLevel) + _level);
            PlayerPrefs.Save();
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
            _selectedCharacter = SelectedCharacterDefault;
            LoadConditionsFromPriceList();

            SaveData();
        }
#endif
    }
}