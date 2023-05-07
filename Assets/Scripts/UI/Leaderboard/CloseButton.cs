using UnityEngine.UI;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private Image _panel;

    public void OnClick()
    {
        Close();
    }

    private void Close()
    {
        _panel.gameObject.SetActive(false);
    }
}
