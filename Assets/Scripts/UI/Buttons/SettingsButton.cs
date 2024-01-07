using Assets.Scripts.UI.MainMenu;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class SettingsButton : MonoBehaviour
    {
        [SerializeField] private Setting _setting;

        public void OnClick()
        {
            _setting.gameObject.SetActive(true);
        }
    }
}