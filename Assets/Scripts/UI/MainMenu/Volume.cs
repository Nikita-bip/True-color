using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    public class Volume : MonoBehaviour
    {
        [SerializeField] private Sprite _volumeOff;
        [SerializeField] private Sprite _volumeOn;
        [SerializeField] private Button _volumeButton;
        [SerializeField] private AudioSource[] _audios;

        public static bool IsOn;

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
}