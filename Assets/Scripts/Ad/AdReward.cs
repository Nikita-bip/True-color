using UnityEngine;
using UnityEngine.UI;

public class AdReward : MonoBehaviour
{
    private const string _inactiveButton = nameof(InactiveButton);

    [SerializeField] private AdShower _adShower;
    [SerializeField] private Button _adv;

    private float _delay = 2f;

    public void OnClick()
    {
        _adv.interactable = false;
        Invoke(_inactiveButton, _delay);
        _adShower.Show();
    }

    private void InactiveButton()
    {
        _adv.interactable = true;
    }
}