using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedColor : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Material[] _colorsBackground;
    [SerializeField] private Material[] _colorsText;
    [SerializeField] private TMP_Text _timer;

    private void Update()
    {
        if (_timer.text == "5")
        {
            GenerateRandom();
        }
    }

    private void GenerateRandom()
    {
        for (int i = 0; i < _colorsBackground.Length; i++)
        {
            _background.material = _colorsBackground[i];
        }

        for (int i = 0; i < _colorsText.Length; i++)
        {
            _text.color = _colorsText[i].color;
        }
    }

        //int rightColorBackground = Random.Range(0, _colors.Length);
        //int rightColorText = Random.Range(0, _colors.Length);

        //if (rightColorBackground != rightColorText)
        //{
        //    _text.color = _colors[rightColorText].color;
        //    _background.material = _colors[rightColorBackground];
        //}
        //else 
        //{
        //    Debug.Log("Одинаковые цвета");
        //}

}
