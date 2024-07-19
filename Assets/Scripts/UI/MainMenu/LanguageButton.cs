using Lean.Localization;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class LanguageButton : MonoBehaviour
    {
        [SerializeField] private string _language;

        public void OnClick()
        {
            SwitchLanguage();
        }

        private void SwitchLanguage()
        {
            LeanLocalization.SetCurrentLanguageAll(_language);
            LeanLocalization.UpdateTranslations();

            PlayerPrefs.SetString(Constants.Language, _language);
            PlayerPrefs.Save();
        }
    }
}