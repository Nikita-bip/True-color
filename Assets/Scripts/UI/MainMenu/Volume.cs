using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    public class Volume : MonoBehaviour
    {
        public static bool IsOn;

        [SerializeField] private Sprite _volumeOff;
        [SerializeField] private Sprite _volumeOn;
        [SerializeField] private Button _volumeButton;
        [SerializeField] private AudioSource[] _audios;

        public void OffSound()
        {
            if (IsOn == false)
            {
                PlayerPrefs.SetInt(Constants.StrMusic, 0);
            }
            else
            {
                PlayerPrefs.SetInt(Constants.StrMusic, 1);
            }
        }

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
            if (PlayerPrefs.GetInt(Constants.StrMusic) == 0)
            {
                _volumeButton.GetComponent<Image>().sprite = _volumeOn;
                IsOn = true;

                foreach (var audio in _audios)
                {
                    audio.enabled = true;
                }
            }
            else
            {
                _volumeButton.GetComponent<Image>().sprite = _volumeOff;
                IsOn = false;

                foreach (var audio in _audios)
                {
                    audio.enabled = false;
                }
            }
        }
    }
}