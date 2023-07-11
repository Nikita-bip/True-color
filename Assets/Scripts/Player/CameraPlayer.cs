using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private List<Player> _players;
    //[SerializeField] private Transform _player;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        foreach (var player in _players)
        {
            if (player.gameObject.activeSelf == true)
            {
                Vector3 desiredPosition = player.transform.position + _offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
                transform.position = smoothedPosition;

                transform.LookAt(player.transform);
            }
        }

        //Vector3 desiredPosition = _player.position + _offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        //transform.position = smoothedPosition;

        //transform.LookAt(_player);
    }

}
