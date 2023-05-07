using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Sprite _volumeOff;
    [SerializeField] private Sprite _volumeOn;
    [SerializeField] private Button _volumeButton;
    [SerializeField] private AudioSource _audio;

    public bool IsOn;

    private void Start()
    {
        IsOn = true;
    }

    private void Update()
    {
        ChangeVolume();
    }

    private void ChangeVolume()
    {
        if (PlayerPrefs.GetInt(Constantes.StrMusic) == 0)
        {
            _volumeButton.GetComponent<Image>().sprite = _volumeOn;
            _audio.enabled = true;
            IsOn = true;
        }
        else
        {
            _volumeButton.GetComponent<Image>().sprite = _volumeOff;
            _audio.enabled = false;
            IsOn = false;
        }
    }

    public void OffSound()
    {
        if (IsOn == false)
        {
            PlayerPrefs.SetInt(Constantes.StrMusic, 0);
        }
        else
        {
            PlayerPrefs.SetInt(Constantes.StrMusic, 1);
        }
    }
}
