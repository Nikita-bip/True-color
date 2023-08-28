using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;
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

    [HideInInspector] public bool IsOpenedSwitcher = false;
    [HideInInspector] public bool IsOpenedTimer = false;

    private void Start()
    {
        Time.timeScale = 0f;
        _mainCamera.SetActive(false);
        _mainCanvas.SetActive(false);
        _tutorialCamera.SetActive(true);
        _tutorialCanvas.SetActive(true);
        _counter = 0;
        _texts[_counter].gameObject.SetActive(true);
    }

    public void OnClick()
    {
        _counter++;

        if (_counter >= _texts.Length)
        {
            _counter = 0;
            _mainCamera.SetActive(true);
            _mainCanvas.SetActive(true);
            _tutorialCamera.SetActive(false);
            _tutorialCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (_counter != 0)
        {
            _texts[_counter - 1].gameObject.SetActive(false);
        }

        if (_counter == 1)
        {
            _tutorialTimer.SetActive(true);
            _timerPointer.SetActive(true);
        }
        else
        {
            _timerPointer.SetActive(false);
        }

        if (_counter == 2)
        {
            foreach (var plane in _plane)
            {
                plane.SetActive(false);
            }
        }
        else
        {
            foreach (var plane in _plane)
            {
                plane.SetActive(true);
            }
        }

        if (_counter == 3)
        {
            _tutorialColor.SetActive(true);
            _colorPointer.SetActive(true);
        }
        else
        {
            _colorPointer.SetActive(false);
        }

        if (_counter == 5)
        {
            _tutorialSwitcher.SetActive(true);
            _switcherPointer.SetActive(true);
        }
        else
        {
            _switcherPointer.SetActive(false);
        }

        _texts[_counter].gameObject.SetActive(true);
    }
}
