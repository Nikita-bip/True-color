using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Finish _finish;
    [SerializeField] private Dead _dead;

    private float _gravityForce;
    private Vector3 _moveVector;
    private Animator _animator;
    private CharacterController _characterController;
    private float _forceOfAttraction = -1f;
    private float _stopSpeed = 0f;
    private float _maximumMagnitudeDelta = 0.0f;
    private float _forceOfWeightlessness = 20f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if ((_finish.IsFinished == true) || (_dead.IsDead == true))
        {
            _speedMove = _stopSpeed;
        }

        if (Application.isMobilePlatform)
        {
            MoveByJoystick();
        }
        else
        {
            _joystick.gameObject.SetActive(false);
            MoveByKeyboard();
        }
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
            _animator.SetBool(Constantes.StrMove, true);
        }
        else
        {
            _animator.SetBool(Constantes.StrMove, false);
        }

        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, _maximumMagnitudeDelta);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        _moveVector.y = _gravityForce;
        _characterController.Move(_moveVector * Time.fixedDeltaTime);
    }

    private void MoveByJoystick()
    {
        Vector3 moveVector = new Vector3(_joystick.Horizontal * _speedMove, 0, _joystick.Vertical * _speedMove);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, _speedMove, _maximumMagnitudeDelta);
            transform.rotation = Quaternion.LookRotation(direct);
            _animator.SetBool(Constantes.StrMoveJoystic, true);
        }
        else
        {
            _animator.SetBool(Constantes.StrMoveJoystic, false);
        }

        moveVector.y = _gravityForce;
        _characterController.Move(moveVector * Time.fixedDeltaTime);
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded)
        {
            _gravityForce -= _forceOfWeightlessness * Time.deltaTime;
        }
        else
        {
            _gravityForce = _forceOfAttraction;
        }
    }
}