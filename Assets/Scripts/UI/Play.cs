using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class Play : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}