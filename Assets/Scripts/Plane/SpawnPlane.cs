using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Timer))]
public class SpawnPlane : MonoBehaviour
{
    [SerializeField] private GameObject[] _plane;
    [SerializeField] private Material[] _colors;
    [SerializeField] private Material _standartMaterial;

    private Timer _timer;

    private void Start()
    {
        _timer = GetComponent<Timer>();
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
                _plane[i].SetActive(false);
            }

            if (_timer.CountOfSeconds == _timer.TimeStart)
            {
                _plane[i].SetActive(true);
            }
        }
    }

    private void PaintPlane()
    {
        foreach(var plane in _plane)
        {
            if (plane.GetComponent<MeshRenderer>().material = _standartMaterial)
            {
                plane.GetComponent<MeshRenderer>().material = _colors[Random.Range(0, _colors.Length)];
            }
        }
    }
}
