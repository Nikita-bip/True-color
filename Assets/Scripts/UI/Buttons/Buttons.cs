using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(Constantes.StrTutorialScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constantes.StrMainMenuScene);
    }

    public void NextLevelButton()
    {
        int nextLevel = Random.Range(3, 14);

        SceneManager.LoadScene(nextLevel);
    }

    public void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentLevel);
    }
}
