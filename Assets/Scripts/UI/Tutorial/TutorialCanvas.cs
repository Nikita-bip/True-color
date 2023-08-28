using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    private void OnDisable()
    {
        PlayerPrefs.SetInt(Constantes.StrTutorial, PlayerPrefs.GetInt(Constantes.StrTutorial) + 1);

        PlayerPrefs.Save();
    }
}
