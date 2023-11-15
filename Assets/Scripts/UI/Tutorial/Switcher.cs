using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Switcher : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;
    [SerializeField] private Timer _timer;

    private bool _flag = true;
    private int _selectedText = 0;

    private void Start()
    {
        _texts[_selectedText].gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _timer.Restarting += IncreaseTextNumber;
        _timer.IsZero += SwitchText;
    }

    private void OnDisable()
    {
        _timer.Restarting -= IncreaseTextNumber;
        _timer.IsZero -= SwitchText;
    }

    private void IncreaseTextNumber(bool restart)
    {
        if (restart == true & _flag == true)
        {
            _selectedText++;
            _flag = false;

            if (_selectedText >= _texts.Length)
            {
                _selectedText = 0;
            }
        }

        if (restart == false)
        {
            _flag = true;
        }
    }

    private void SwitchText(bool zero)
    {
        if (zero == false)
        {
            if (_selectedText != 0)
            {
                _texts[_selectedText - 1].gameObject.SetActive(false);
            }

            if (_selectedText == 0)
            {
                _texts[_texts.Length - 1].gameObject.SetActive(false);
            }

            _texts[_selectedText].gameObject.SetActive(true);
        }
    }
}