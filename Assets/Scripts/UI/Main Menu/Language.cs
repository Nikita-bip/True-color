using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    [SerializeField] private Button _russianButton;
    [SerializeField] private Button _englishButton;
    [SerializeField] private Button _turkishButton;
    [SerializeField] private LeanLocalization _leanLocalization;

    private void Update()
    {
        ChangeLanguage();
    }

    private void ChangeLanguage()
    {
        switch (PlayerPrefs.GetString(Constantes.Language))
        {
            case "ru":
                _russianButton.gameObject.SetActive(true);
                _leanLocalization.SetCurrentLanguage("Russian");
                _englishButton.gameObject.SetActive(false);
                _turkishButton.gameObject.SetActive(false);
                break;
            case "en":
                _englishButton.gameObject.SetActive(true);
                _leanLocalization.SetCurrentLanguage("English");
                _russianButton.gameObject.SetActive(false);
                _turkishButton.gameObject.SetActive(false);
                break;
            case "tr":
                _turkishButton.gameObject.SetActive(true);
                _leanLocalization.SetCurrentLanguage("Turkish");
                _russianButton.gameObject.SetActive(false);
                _englishButton.gameObject.SetActive(false);
                break;
        }

        PlayerPrefs.Save();
    }
}