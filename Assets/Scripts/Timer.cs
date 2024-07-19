using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Timer : MonoBehaviour
{
    private const string _restartTimer = nameof(RestartTimer);

    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _timeStart;

    private float _countOfSeconds;
    private Animator _animator;
    private float _delay = 1f;

    public event Action<bool> IsZero;
    public event Action<bool> Restarting;

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
            Restarting?.Invoke(false);
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
        Restarting?.Invoke(true);
    }
}