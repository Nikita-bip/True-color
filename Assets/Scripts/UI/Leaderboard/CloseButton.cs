using UnityEngine.UI;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private Image _panel;

    private const string _close = nameof(Close);

    public void OnClick()
    {
        Invoke(_close, 0.4f);
    }

    private void Close()
    {
        _panel.gameObject.SetActive(false);
    }
}
