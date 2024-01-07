using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Plane
{
    public class SwitchColor : MonoBehaviour
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
            _timer.Restarting += IncreaseColor;
            _timer.IsZero += Switch;
        }

        private void OnDisable()
        {
            _timer.Restarting -= IncreaseColor;
            _timer.IsZero -= Switch;
        }

        private void IncreaseColor(bool restart)
        {
            if (restart == true & _flag == true)
            {
                _selectedColor++;
                _flag = false;

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

        private void Switch(bool zero)
        {
            if (zero == false)
            {
                _background.material = _colorsBackground[_selectedColor];
            }
        }
    }
}