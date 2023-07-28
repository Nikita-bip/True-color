using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Switcher : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;
    [SerializeField] private Timer _timer;

    private Animator _animator;
    private bool _flag = true;
    private int _selectedText = 0;

    private void Start()
    {
        _texts[_selectedText].gameObject.SetActive(true);
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _timer.Restarted += IncreaseTextNumber;
        _timer.IsZero += SwitchText;
    }

    private void OnDisable()
    {
        _timer.Restarted -= IncreaseTextNumber;
        _timer.IsZero -= SwitchText;
    }

    private void IncreaseTextNumber(bool restart)
    {
        if (restart == true & _flag == true)
        {
            _selectedText++;
            Debug.Log($"ïëþñ òåêñò");

            _flag = false; //ÎÒÐÅÄÀÊÒÈÐÎÂÀÒÜ!

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
