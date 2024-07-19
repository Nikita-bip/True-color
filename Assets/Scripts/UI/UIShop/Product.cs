using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.UIShop
{
    public class Product : MonoBehaviour
    {
        public event Action<Product, Price> Clicked;

        [SerializeField] private Image _image;
        [SerializeField] private GameObject _iconCheck;
        [SerializeField] private GameObject _iconLock;
        [SerializeField] private GameObject _adIcon;
        [SerializeField] private GameObject _coinIcon;
        [SerializeField] private TMP_Text _cost;

        private Price _price;
        private Button _button;

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void Init(Price price)
        {
            _price = price;

            _image.sprite = price.Image;

            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);

            _iconCheck.SetActive(false);

            int numberOfOperationBeforeBuy = PlayerData.Instance.ConditionsForCharacters[price.PlayerCharacterName];

            if (numberOfOperationBeforeBuy == 0)
            {
                Unlock();
            }
            else if (price.IsBuyForAd)
            {
                _adIcon.SetActive(price.IsBuyForAd);
                _cost.text = $"{numberOfOperationBeforeBuy} / {price.Cost}";
            }
            else
            {
                _cost.text = NumberSeparator.SplitNumber(price.Cost);
            }

            if (PlayerData.Instance.SelectedCharacter == (int)price.PlayerCharacterName)
                Select();
        }

        private void OnClick() => Clicked?.Invoke(this, _price);

        public void Unlock()
        {
            _iconLock.SetActive(false);
            _adIcon.SetActive(false);
            _coinIcon.SetActive(false);
            _cost.text = " ";
        }

        public void Select()
        {
            _iconCheck.SetActive(true);
        }

        public void UnSelect()
        {
            _iconCheck.SetActive(false);
        }

        public void UpdateCostText()
        {
            int numberOfOperationBeforeBuy = PlayerData.Instance.ConditionsForCharacters[_price.PlayerCharacterName];
            _cost.text = $"{numberOfOperationBeforeBuy} / {_price.Cost}";
        }
    }
}