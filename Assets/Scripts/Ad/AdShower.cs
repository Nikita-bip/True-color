using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AdShower : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private float[] _volumes;
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private WebEventSystem _webEventSystem;

    public static bool IsEnd = true;
    private static AudioSource[] _allAudioSources;
    private static float[] _allVolumes;
    private bool _isMuted;

    protected void OnOpenCallback()
    {
        for (var i = 0; i < _allAudioSources.Length; i++)
        {
            _allAudioSources[i].volume = 0;
        }

        PauseGame();
    }

    protected void OnCloseCallback()
    {
        for (var i = 0; i < _allAudioSources.Length; i++)
        {
            _allAudioSources[i].volume = _allVolumes[i];
        }
    }

    protected void OnOpenCallbackInLevel()
    {
        foreach (var audioSource in _audioSources)
        {
            audioSource.volume = 0;
        }

        PauseGame();
    }

    protected void OnCloseCallbackInLevel(bool isClosed)
    {
        for (var i = 0; i < _allAudioSources.Length; i++)
        {
            _allAudioSources[i].volume = _allVolumes[i];
        }

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

    public abstract void Show();

    private void Update()
    {
        if (IsEnd == false & _webEventSystem.isFocused == true)
        {
            SoundMuter.Mute();
        }
        else
        {
            SoundMuter.Unmute();
        }
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;

        if (_isMuted)
        {
            return;
        }

        IsEnd = true;
        _audioListener.enabled = true;
        SoundMuter.Unmute();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;

        _isMuted = SoundMuter.IsMuted;

        IsEnd = false;
        _audioListener.enabled = false;
        SoundMuter.Mute();
    }
}