using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private int _nextScene;
    [SerializeField] private Slider _scale;

    public void Loading()
    {
        _loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync());
    }
    private IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(_nextScene);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            _scale.value = loadAsync.progress;

            if (loadAsync.progress >= 9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }

}
