using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _smoothSpeed = 0.125f;
    [SerializeField] Vector3 _offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(_player);
    }

}
