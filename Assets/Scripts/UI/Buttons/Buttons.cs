using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI.Buttons
{
    public class Buttons : MonoBehaviour
    {
        public void PlayGame()
        {
            if (PlayerPrefs.GetInt(Constants.StrTutorial) > 0)
            {
                NextLevelButton();
            }
            else
            {
                SceneManager.LoadScene(Constants.StrTutorialScene);
            }
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(Constants.StrMainMenuScene);
            PlayerPrefs.Save();
        }

        public void Shop()
        {
            SceneManager.LoadScene(Constants.StrShopScene);
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
}