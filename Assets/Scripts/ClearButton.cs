using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
