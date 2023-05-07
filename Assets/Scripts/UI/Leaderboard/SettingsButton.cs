using UnityEngine.UI;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private Image _settingsPanel;

    public void OnClick()
    {
        OpenSettingsPanel();
    }

    private void OpenSettingsPanel()
    {
        _settingsPanel.gameObject.SetActive(true);
    }
}
