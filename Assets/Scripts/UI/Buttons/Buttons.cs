using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        if(PlayerPrefs.GetInt(Constantes.StrTutorial) > 0)
            NextLevelButton();
        else
            SceneManager.LoadScene(Constantes.StrTutorialScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constantes.StrMainMenuScene);
        PlayerPrefs.Save();
    }

    public void Shop()
    {
        SceneManager.LoadScene(Constantes.StrShopScene);

    }

    public void NextLevelButton()
    {
        int nextLevel = Random.Range(3, 13);

        SceneManager.LoadScene(nextLevel);
        PlayerPrefs.Save();
    }

    public void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentLevel);
    }
}
