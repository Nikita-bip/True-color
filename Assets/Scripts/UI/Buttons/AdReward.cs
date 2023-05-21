using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdReward : MonoBehaviour
{
    [SerializeField] private AdShower _adShower;
    [SerializeField] private Button _adv;

    private const string _inactiveButton = nameof(InactiveButton);

    public void OnClick()
    {
        _adv.interactable = false;
        Invoke(_inactiveButton, 2f);
        _adShower.Show();
        PlayerPrefs.SetInt(Constantes.StrCountMoney, PlayerPrefs.GetInt(Constantes.StrCountMoney) + 100);
        PlayerPrefs.Save();
    }

    private void InactiveButton()
    {
        _adv.interactable = true;
    }
}
