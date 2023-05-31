using UnityEngine;

public abstract class AdShower : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private float[] _volumes;
    [SerializeField] private AudioListener _audioListener;

    private static AudioSource[] s_audioSources;
    private static float[] s_volumes;

    private void Awake()
    {
        s_audioSources = _audioSources;
        s_volumes = _volumes;
    }

    public abstract void Show();

    protected void OnOpenCallBack()
    {
        Time.timeScale = 0;
        _audioListener.enabled = false;
        foreach (var audioSource in _audioSources)
            audioSource.volume = 0;
    }

    protected void OnCloseCallBack()
    {
        Time.timeScale = 1;
        _audioListener.enabled = true;

        for (var i = 0; i < s_audioSources.Length; i++)
            s_audioSources[i].volume = s_volumes[i];

        PlayerPrefs.SetInt(Constantes.StrCountMoney, PlayerPrefs.GetInt(Constantes.StrCountMoney) + 100);
        PlayerPrefs.Save();
    }

    protected void OnCloseCallBack(bool state)
    {
        if (state)
            return;

        Time.timeScale = 1;
        _audioListener.enabled = true;
        foreach (var audioSource in _audioSources)
            audioSource.volume = 0.01f;
    }
}
