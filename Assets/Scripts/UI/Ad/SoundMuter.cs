using UnityEngine;

public class SoundMuter : MonoBehaviour
{
    [SerializeField] private VideoAdShower _adShower;
    public static bool IsMuted { get; private set; }

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
}