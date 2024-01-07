using TMPro;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.UIShop
{
    public class ShopStart : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private ShopTest _shop;
        [SerializeField] private TMP_Text _money;

        private void Awake()
        {
            _playerData.Init();
            StartCoroutine(WaitForLoadPlayerData());
        }

        private void OnDestroy()
        {
            _playerData.SaveData();
            _playerData.MoneyChanged -= InstanceOnMoneyChanged;
        }

        private IEnumerator WaitForLoadPlayerData()
        {
            var waitForEndOfFrame = new WaitForEndOfFrame();

            while (_playerData.IsDataLoaded == false)
            {
                yield return waitForEndOfFrame;
            }

            ApplyGameSettings();
        }

        private void ApplyGameSettings()
        {
            _playerData.MoneyChanged += InstanceOnMoneyChanged;
            _shop.Init();
            _money.text = NumberSeparator.SplitNumber(PlayerData.Instance.Money);
        }

        private void InstanceOnMoneyChanged(int newValue)
        {
            _money.text = NumberSeparator.SplitNumber(PlayerData.Instance.Money);
        }
    }
}