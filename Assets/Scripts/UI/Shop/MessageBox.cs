using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    [SerializeField] private GameObject _messageBox;
    [SerializeField] private Button _buttonClose;
    [SerializeField] private Button _buttonConfirm;

    public event UnityAction<bool> IsConfirmedAction;

    private void Start()
    {
        _buttonClose.onClick.AddListener(OnButtonCloseClick);
        _buttonConfirm.onClick.AddListener(OnButtonConfirmClick);
    }

    private void OnDestroy()
    {
        _buttonClose.onClick.RemoveListener(OnButtonCloseClick);
        _buttonConfirm.onClick.RemoveListener(OnButtonConfirmClick);
    }

    public void ShowMessageBox()
    {
        _messageBox.SetActive(true);
    }

    private void OnButtonCloseClick()
    {
        IsConfirmedAction?.Invoke(false);
        _messageBox.SetActive(false);
    }

    private void OnButtonConfirmClick()
    {
        IsConfirmedAction?.Invoke(true);
        _messageBox.SetActive(false);
    }
}