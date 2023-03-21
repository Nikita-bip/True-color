using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void Move(float directionX, float directionZ)
    {
        _rigidbody.velocity = new Vector3(directionX * _movementSpeed, _rigidbody.velocity.y, directionZ * _movementSpeed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Finish>(out Finish _finish))
        {
            _rigidbody.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
