using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameObject _spawnPoint;

    private float _gravityForce;
    private Vector3 _moveVector;
    private float _delay = 0.1f;
    private Animator _animator;
    private CharacterController _characterController;
    private const string _respawn = nameof(Respawn);

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveByJoystick();
        MoveByKeyboard();
    }

    private void Update()
    {
        GamingGravity();
    }

    private void MoveByKeyboard()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * _speedMove;
        _moveVector.z = Input.GetAxis("Vertical") * _speedMove;

        if (_moveVector.x != 0 || _moveVector.z != 0)
        {
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);
        }

        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        _moveVector.y = _gravityForce;
        _characterController.Move(_moveVector * Time.fixedDeltaTime);
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded)
        {
            _gravityForce -= 20f * Time.deltaTime;
        }
        else
        {
            _gravityForce = -1f;
        }
    }

    private void MoveByJoystick()
    {
        Vector3 _moveVector = new Vector3(_joystick.Horizontal * _speedMove, 0, _joystick.Vertical * _speedMove);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
            _animator.SetBool("MoveJoystic", true);
        }
        else
        {
            _animator.SetBool("MoveJoystic", false);
        }

        _moveVector.y = _gravityForce;
        _characterController.Move(_moveVector * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Finish _finish))
        {
            _characterController.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            _animator.SetInteger("Dance", 2);
        }

        if (collider.TryGetComponent(out Rebirth rebirth))
        {
            _characterController.enabled = false;
            Invoke(_respawn, _delay);
        }
    }

    private void Respawn()
    {
        _characterController.transform.position = _spawnPoint.transform.position;
        _characterController.enabled = true;
    }
}
