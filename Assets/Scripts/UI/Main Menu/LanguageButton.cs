using UnityEngine;
using Lean.Localization;

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

        PlayerPrefs.SetString(Constantes.Language, _language);
        PlayerPrefs.Save();
    }
}
