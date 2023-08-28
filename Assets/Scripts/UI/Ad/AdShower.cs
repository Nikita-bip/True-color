using Agava.YandexGames.Samples;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.EventSystems;
=======
>>>>>>> 7fcba35c0f20af8c87af357ea4ab3ee4ccb24927
using UnityEngine.SceneManagement;

public abstract class AdShower : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private float[] _volumes;
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private WebEventSystem _webEventSystem;

    private static AudioSource[] s_audioSources;
    private static float[] s_volumes;
    private bool _isMuted;
<<<<<<< HEAD
    public static bool IsEnd = true;

    private void Update()
    {
        if (IsEnd == false & _webEventSystem.isFocused == true)
        {
            SoundMuter.Mute();
        }
        //else if (_webEventSystem.isFocused == true)
        //{
        //    AudioListener.pause = true;
        //    AudioListener.volume = 0f;
        //}
        else
        {
            SoundMuter.Unmute();
        }
    }

    protected void OnOpenCallback()
    {
        for (var i = 0; i < s_audioSources.Length; i++)
            s_audioSources[i].volume = 0;

        PauseGame();
    }

    protected void OnCloseCallback()
    {
        for (var i = 0; i < s_audioSources.Length; i++)
            s_audioSources[i].volume = s_volumes[i];

=======

    protected void OnOpenCallback()
    {
        PauseGame();
    }

    protected void OnCloseCallback()
    {
>>>>>>> 7fcba35c0f20af8c87af357ea4ab3ee4ccb24927
        ContinueGame();
    }

    protected void OnOpenCallbackInLevel()
    {
        foreach (var audioSource in _audioSources)
            audioSource.volume = 0;

        PauseGame();
    }

    protected void OnCloseCallbackInLevel(bool isClosed)
    {
        for (var i = 0; i < s_audioSources.Length; i++)
            s_audioSources[i].volume = s_volumes[i];

        ContinueGame();

        int nextLevel = UnityEngine.Random.Range(3, 13);

        SceneManager.LoadScene(nextLevel);
        PlayerPrefs.Save();
    }

    protected void OnCloseCallBackReward()
    {
        PlayerData.Instance.Money += 50;
        PlayerPrefs.Save();
    }

    protected void OnErrorCallback(string errorMessage)
    {
        ContinueGame();
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;

        if (_isMuted)
            return;

<<<<<<< HEAD
        IsEnd = true;
=======
>>>>>>> 7fcba35c0f20af8c87af357ea4ab3ee4ccb24927
        _audioListener.enabled = true;
        SoundMuter.Unmute();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;

        _isMuted = SoundMuter.IsMuted;

<<<<<<< HEAD
        IsEnd = false;
=======
>>>>>>> 7fcba35c0f20af8c87af357ea4ab3ee4ccb24927
        _audioListener.enabled = false;
        SoundMuter.Mute();
    }

    public abstract void Show();
<<<<<<< HEAD
}
=======
}
>>>>>>> 7fcba35c0f20af8c87af357ea4ab3ee4ccb24927
