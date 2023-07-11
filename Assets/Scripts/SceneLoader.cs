using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Scene_2");
    }

    public void PrevScene()
    {
        SceneManager.LoadScene("Scene_1");
    }
}
