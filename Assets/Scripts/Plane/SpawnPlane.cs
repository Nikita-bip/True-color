using System.Collections;
using System.Collections.Generic;
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
        SwitchPlane();
    }

    private void SwitchPlane()
    {
        for (int i = 0; i < _plane.Length; i++)
        {
            if (_timer.CountOfSeconds == 0)
            {
                if (_plane[i].GetComponent<MeshRenderer>().sharedMaterial == _selectColor[_selectedColorNumber])
                {
                    _plane[i].SetActive(true);
                }
                else
                {
                    _plane[i].SetActive(false);
                }
            }

            if (_timer.CountOfSeconds > 0)
            {
                _plane[i].SetActive(true);
            }

            if (_timer.CountOfSeconds == 3)
            {
                _selectedColorNumber++;
            }

            if(_selectedColorNumber >= _selectColor.Length)
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
