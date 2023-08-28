using UnityEngine;

public class ClearButton : MonoBehaviour
{
    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
