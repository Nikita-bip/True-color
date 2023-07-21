using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

[RequireComponent(typeof(Animator))]
public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _timeStart;

    private float _countOfSeconds;
    private Animator _animator;
    private float _delay = 1f; 
    private const string _restartTimer = nameof(RestartTimer);

    public event UnityAction<bool> IsZero;
    public event UnityAction<bool> Restarted;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _countOfSeconds = _timeStart;
        _timerText.text = _countOfSeconds.ToString();
    }

    private void Update()
    {
        if (_countOfSeconds < 0)
        {
            _countOfSeconds = 0;
            IsZero?.Invoke(true);
            Invoke(_restartTimer, _delay);
            Restarted?.Invoke(false);
        }
        else
        {
            _countOfSeconds -= Time.deltaTime;
            _timerText.text = Mathf.Round(_countOfSeconds).ToString();
        }
    }

    private void RestartTimer()
    {
        _countOfSeconds = _timeStart;
        IsZero?.Invoke(false);
        Restarted?.Invoke(true);
    }
}