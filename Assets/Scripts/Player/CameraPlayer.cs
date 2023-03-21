using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
       // 1 скрипт
    //[SerializeField] Transform _player;

    //private Vector3 _deltaPosition;

    //private void Start()
    //{
    //    _deltaPosition = transform.position - _player.position;
    //}

    //private void Update()
    //{
    //    transform.position = _player.position + _deltaPosition;
    //}

    //2 скрипт
    public Transform target;
    public float smooth = 5.0f;
    public Vector3 offset = new Vector3(0, 2, -5);
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
    }
}
