using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] public float TimeStart;

    [HideInInspector] public float CountOfSeconds;

    private Animator _animator;
    private float _delay = 1f;
    private const string _restartTimer = nameof(RestartTimer);

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
