using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class AnonimLanguage : MonoBehaviour
    {
        public static string GetAnonymous(string lang)
        {
            switch (lang)
            {
                case "en":
                    return "Anonymous";
                case "ru":
                    return "Аноним";
                case "tr":
                    return "Anonim";
                default:
                    return "Anonymous";
            }
        }
    }
}