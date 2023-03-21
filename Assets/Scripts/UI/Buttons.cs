using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextLevelButton()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = Random.Range(2, 4);

        if (nextLevel != currentLevel) 
        {
            SceneManager.LoadScene(Random.Range(2, 5));
        }
        else
        {
            Debug.Log("�� �����");
        }
    }
}