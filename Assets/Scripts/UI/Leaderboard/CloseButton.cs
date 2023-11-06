using UnityEngine.UI;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private Image _panel;
    [SerializeField] private Animator _settingAnimator;
    [SerializeField] private Animator _labelSettingAnimator;

    private const string _close = nameof(Close);

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        _animator.SetBool("Open", false);
        _settingAnimator.SetBool("Open", false);
        _labelSettingAnimator.SetBool("Open", false);
        Invoke(_close, 0.6f);
    }

    private void Close()
    {
        _panel.gameObject.SetActive(false);
    }
}