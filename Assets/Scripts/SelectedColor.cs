using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedColor : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Material[] _colorsBackground;
    [SerializeField] private Timer _timer;

    private int _selectedColor = 0;
    private bool _flag = true;

    private void Start()
    {
        _background.material = _colorsBackground[_selectedColor];
    }

    private void OnEnable()
    {
        _timer.Restarted += IncreaseColor;
        _timer.IsZero += SwitchColor;
    }

    private void OnDisable()
    {
        _timer.Restarted -= IncreaseColor;
        _timer.IsZero -= SwitchColor;
    }

    private void IncreaseColor(bool restart)
    {
        if (restart == true & _flag == true)
        {
            _selectedColor++;
            Debug.Log($"ïëþñ öâåò");

            _flag = false; //ÎÒÐÅÄÀÊÒÈÐÎÂÀÒÜ!

            if (_selectedColor >= _colorsBackground.Length)
            {
                _selectedColor = 0;
            }
        }

        if (restart == false)
        {
            _flag = true;
        }
    }

    private void SwitchColor(bool zero)
    {
        if (zero == false)
        {
            _background.material = _colorsBackground[_selectedColor];
        }
    }
}
