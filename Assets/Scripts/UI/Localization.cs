using Agava.YandexGames;
using UnityEngine;
using Lean.Localization;
using System.Collections;

[RequireComponent(typeof(LeanLocalization))]
public class Localization : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;
    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        string language = YandexGamesSdk.Environment.i18n.lang;

            switch (language)
            {
                case "en":
                    _leanLocalization.SetCurrentLanguage("English");
                    break;

                case "ru":
                    _leanLocalization.SetCurrentLanguage("Russian");
                    break;

                case "tr":
                    _leanLocalization.SetCurrentLanguage("Turkish");
                    break;
            }

        PlayerPrefs.SetString(Constantes.Language, language);
        PlayerPrefs.Save();
    }
}
