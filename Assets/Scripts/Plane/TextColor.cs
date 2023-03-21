using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColor : MonoBehaviour
{
    [SerializeField] private TMP_Text _colorText;
    [SerializeField] private Material[] _colors;

    private Timer _timer;
    private Color[] _color =
    {
        Color.red,
    };

    private void Start()
    {
        _timer = GetComponent<Timer>();
    }
}
