using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] Transform _player;

    private Vector3 _deltaPosition;

    private void Start()
    {
        _deltaPosition = transform.position - _player.position;
    }

    private void Update()
    {
        transform.position = _player.position + _deltaPosition;
    }
}
