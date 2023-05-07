using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(Constantes.StrTutorialScene);
    }

    public void TestScene()
    {
        SceneManager.LoadScene(5);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(Constantes.StrMainMenuScene);
    }

    public void NextLevelButton()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = Random.Range(3, 14);

        if (nextLevel != currentLevel) 
        {
            SceneManager.LoadScene(Random.Range(3, 14));
        }
        else
        {
            Debug.Log("Не попал");
        }
    }
}
