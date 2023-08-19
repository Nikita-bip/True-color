using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AdShower : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private float[] _volumes;
    [SerializeField] private AudioListener _audioListener;

    private static AudioSource[] s_audioSources;
    private static float[] s_volumes;
    private bool _isMuted;

    protected void OnOpenCallback()
    {
        PauseGame();
    }

    protected void OnCloseCallback()
    {
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

        _audioListener.enabled = true;
        SoundMuter.Unmute();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;

        _isMuted = SoundMuter.IsMuted;

        _audioListener.enabled = false;
        SoundMuter.Mute();
    }

    public abstract void Show();
}
