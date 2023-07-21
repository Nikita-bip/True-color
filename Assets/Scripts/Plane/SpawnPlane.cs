using System.Collections;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    [SerializeField] private GameObject[] _plane;
    [SerializeField] private Material[] _colors;
    [SerializeField] private Material[] _selectColor;
    [SerializeField] private Timer _timer;

    private int _countOfPlane;
    private int _countOfColors;
    private int _counter = 0;
    private int _indexOfColor = 0;
    private int _selectedColorNumber = 0;


    private void Start()
    {
        _countOfPlane = _plane.Length;
        _countOfColors = _colors.Length;
        PaintPlane();
    }

    private void Update()
    {
        //Debug.Log($"{_selectedColorNumber}");
    }

    private void OnEnable()
    {
        _timer.IsZero += SwitchPlane;
        _timer.Restarted += IncreaseColorNumber;
    }

    private void OnDisable()
    {
        _timer.IsZero -= SwitchPlane;
        _timer.Restarted -= IncreaseColorNumber;
    }

    private void SwitchPlane(bool zero)
    {
        for (int i = 0; i < _plane.Length; i++)
        {
            if (zero == true)
            {
                if (_selectedColorNumber >= _selectColor.Length)
                {
                    _selectedColorNumber = 0;
                }

                if (_plane[i].GetComponent<MeshRenderer>().sharedMaterial == _selectColor[_selectedColorNumber])
                {
                    _plane[i].SetActive(true);
                    Debug.Log($"{_selectedColorNumber}");
                }
                else
                {
                    _plane[i].SetActive(false);
                }
            }
            else
            {
                _plane[i].SetActive(true);
            }
        }
    }

    private void IncreaseColorNumber(bool restart)
    {
        if (restart == true)
        {
            _selectedColorNumber++;

            if (_selectedColorNumber >= _selectColor.Length)
            {
                _selectedColorNumber = 0;
            }
        }
    }

    private void PaintPlane()
    {
        int _countOfPlanesCertainColor  = _countOfPlane / _countOfColors;

        for (int i = 0; i < _plane.Length; i++) 
        {
            _plane[i].GetComponent<MeshRenderer>().material = _colors[_indexOfColor];
            _counter++;

            if (_counter >= _countOfPlanesCertainColor)
            {
                _counter = 0;
                _indexOfColor++;
            }

            if (_indexOfColor >= _colors.Length)
            {
                _indexOfColor = 0;
            }
        }
    }
}
