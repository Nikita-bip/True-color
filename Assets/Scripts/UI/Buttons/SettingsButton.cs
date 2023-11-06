using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private Setting _setting;

    public void OnClick()
    {
        _setting.gameObject.SetActive(true);
    }
}