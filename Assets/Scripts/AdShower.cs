using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdShower : MonoBehaviour
{
    [SerializeField] private AudioListener _audioListener;

    private Volume _volume;

    private void Start()
    {
        _volume = GetComponent<Volume>();
    }

    public abstract void Show();

    protected void OnOpenCallBack()
    {
        Time.timeScale = 0;

        _audioListener.enabled = false;
        _volume.IsOn = false;
    }

    protected void OnCloseCallBack()
    {
        Time.timeScale = 1;

        _audioListener.enabled = true;
        _volume.IsOn = true;
    }

    protected void OnCloseCallBack(bool state)
    {
        if (state)
            return;

        Time.timeScale = 1;

        _audioListener.enabled = true;
        _volume.IsOn = true;
    }
}
