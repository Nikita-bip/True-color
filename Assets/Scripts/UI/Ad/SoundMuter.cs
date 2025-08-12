using Agava.WebUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMuter : MonoBehaviour
{
    [SerializeField] private VideoAdShower _adShower;
    public static bool IsMuted { get; private set; }

    //private void OnEnable()
    //{
    //    WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    //}

    //private void OnDisable()
    //{
    //    WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    //}

    public static void Mute()
    {
        IsMuted = true;
        AudioListener.volume = IsMuted ? 0f : 1f;
    }

    public static void Unmute()
    {
        IsMuted = false;
        AudioListener.volume = IsMuted ? 0f : 1f;
    }

    //private void OnInBackgroundChange(bool inBackground)
    //{
    //    //if (!IsMuted & AdShowerMainMenu.IsEnd == true)
    //    //{
    //    //    AudioListener.pause = inBackground;
    //    //    AudioListener.volume = inBackground ? 0f : 1f;
    //    //}
    //    if (IsMuted)
    //        return;

    //    Pause(inBackground);
    //}

    //private static void Pause(bool isMuted)
    //{
    //    AudioListener.pause = isMuted;
    //    AudioListener.volume = isMuted ? 0f : 1f;
    //}
}