using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text _timerText;
    [SerializeField] public float TimeStart;

    [HideInInspector] public float CountOfSeconds;

    private float _delay = 2f;
    private const string _restartTimer = nameof(RestartTimer);

    private void Start()
    {
        CountOfSeconds = TimeStart;
        _timerText.text = CountOfSeconds.ToString();
    }

    private void Update()
    {
        if (CountOfSeconds < 0)
        {
            CountOfSeconds = 0;
            Invoke(_restartTimer, _delay);
        }
        else
        {
            CountOfSeconds -= Time.deltaTime;
            _timerText.text = Mathf.Round(CountOfSeconds).ToString();
        }
    }

    private void RestartTimer()
    {
        CountOfSeconds = TimeStart;
    }
}
