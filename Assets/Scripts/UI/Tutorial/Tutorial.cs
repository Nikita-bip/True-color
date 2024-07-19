using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Tutorial
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _tutorialTexts;
        [SerializeField] private GameObject _mainCamera;
        [SerializeField] private GameObject[] _plane;
        [SerializeField] private GameObject _mainCanvas;
        [SerializeField] private GameObject _tutorialTimer;
        [SerializeField] private GameObject _tutorialSwitcher;
        [SerializeField] private GameObject _tutorialColor;
        [SerializeField] private GameObject _tutorialCamera;
        [SerializeField] private GameObject _tutorialCanvas;
        [SerializeField] private GameObject _timerPointer;
        [SerializeField] private GameObject _switcherPointer;
        [SerializeField] private GameObject _colorPointer;

        private int _counter;

        private void Start()
        {
            Time.timeScale = 0f;
            _mainCamera.SetActive(false);
            _mainCanvas.SetActive(false);
            _tutorialCamera.SetActive(true);
            _tutorialCanvas.SetActive(true);
            _counter = 0;
            _tutorialTexts[_counter].gameObject.SetActive(true);
        }

        public void OnClick()
        {
            _tutorialTexts[_counter].gameObject.SetActive(false);
            _counter++;

            if (_counter >= _tutorialTexts.Length)
            {
                _counter = 0;
                _mainCamera.SetActive(true);
                _mainCanvas.SetActive(true);
                _tutorialCamera.SetActive(false);
                _tutorialCanvas.SetActive(false);
                Time.timeScale = 1f;
            }

            switch (_counter)
            {
                case 1:
                    _tutorialTimer.SetActive(true);
                    _timerPointer.SetActive(true);
                    break;
                case 2:
                    foreach (var plane in _plane)
                    {
                        plane.SetActive(false);
                    }
                    break;
                case 3:
                    _tutorialColor.SetActive(true);
                    _colorPointer.SetActive(true);
                    break;
                case 5:
                    _tutorialSwitcher.SetActive(true);
                    _switcherPointer.SetActive(true);
                    break;
            }

            if (_counter != 0)
            {
                _tutorialTexts[_counter - 1].gameObject.SetActive(false);
            }

            _tutorialTexts[_counter].gameObject.SetActive(true);
        }
    }
}