using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISfx : MonoBehaviour
{
    [SerializeField] private Sprite _volumeOff;
    [SerializeField] private Sprite _volumeOn;
    [SerializeField] private Button _volumeButton;
    [SerializeField] private AudioSource[] _audios;

    public static bool IsOnClick;

    private void Start()
    {
        IsOnClick = true;
    }

    private void Update()
    {
        ChangeVolume();
    }

    private void ChangeVolume()
    {
        if (PlayerPrefs.GetInt(Constantes.StrSfx) == 0)
        {
            _volumeButton.GetComponent<Image>().sprite = _volumeOn;
            IsOnClick = true;

            foreach (var audio in _audios)
            {
                audio.enabled = true;
            }
        }
        else
        {
            _volumeButton.GetComponent<Image>().sprite = _volumeOff;
            IsOnClick = false;

            foreach (var audio in _audios)
            {
                audio.enabled = false;
            }
        }
    }

    public void OffClickSound()
    {
        if (IsOnClick == false)
        {
            PlayerPrefs.SetInt(Constantes.StrSfx, 0);
        }
        else
        {
            PlayerPrefs.SetInt(Constantes.StrSfx, 1);
        }
    }
}
