using UnityEngine;

namespace Assets.Scripts.UI.Tutorial
{
    public class TutorialCanvas : MonoBehaviour
    {
        private void OnDisable()
        {
            PlayerPrefs.SetInt(Constants.StrTutorial, PlayerPrefs.GetInt(Constants.StrTutorial) + 1);

            PlayerPrefs.Save();
        }
    }
}