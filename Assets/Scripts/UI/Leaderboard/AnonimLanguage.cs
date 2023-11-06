using UnityEngine;

public class AnonimLanguage : MonoBehaviour
{
    public static string GetAnonymous(string lang)
    {
        switch (lang)
        {
            case "en":
                return "Anonymous";
            case "ru":
                return "������";
            case "tr":
                return "Anonim";
            default:
                return "Anonymous";
        }
    }
}