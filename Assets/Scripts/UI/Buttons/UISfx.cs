using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{
    public class UISfx : MonoBehaviour
    {
        public static bool IsOnClick;

        [SerializeField] private Sprite _volumeOff;
        [SerializeField] private Sprite _volumeOn;
        [SerializeField] private Button _volumeButton;
        [SerializeField] private AudioSource[] _audios;

        public void OffClickSound()
        {
            if (IsOnClick == false)
            {
                PlayerPrefs.SetInt(Constants.StrSfx, 0);
            }
            else
            {
                PlayerPrefs.SetInt(Constants.StrSfx, 1);
            }
        }

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
            if (PlayerPrefs.GetInt(Constants.StrSfx) == 0)
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
    }
}