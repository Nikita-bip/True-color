using Assets.Scripts.Player;
using UnityEngine;

public class FsmStateMovement : FsmState
{
    protected readonly Transform Transform;
    protected readonly float Speed;
    protected readonly Animator Animation;
    protected readonly CharacterController Controller;

    private Vector3 _moveVector;
    private float _gravityForce;
    private float _forceOfAttraction = -1f;
    private float _forceOfWeightlessness = 20f;
    private float _maximumMagnitudeDelta = 0.0f;

    public FsmStateMovement(Fsm fsm, Animator animator, Transform transform, float speed, CharacterController characterController) : base(fsm, animator)
    {
        Transform = transform;
        Speed = speed;
        Animation = animator;
        Controller = characterController;
    }

    public override void Enter()
    {
        Debug.Log($"Movement ({this.GetType().Name}) state [ENTER]");
    }

    public override void Exit()
    {
        Debug.Log($"Movement ({this.GetType().Name}) state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log($"Movement ({this.GetType().Name}) state [UPDATE]");
        GamingGravity();
        Move();
        //var inputDirection = ReadInput();

        //if (inputDirection.sqrMagnitude == 0f)
        //{
        //    Animation.SetBool(Constantes.StrMove, false);
        //    Fsm.SetState<FsmStateIdle>();
        //}
        //else
        //{

        //}

        //Animation.SetBool(Constantes.StrMove, true);
        //Move(inputDirection);
    }

    //protected Vector2 ReadInput()
    //{
    //    _moveVector = Vector3.zero;
    //    _moveVector.x = Input.GetAxis("Horizontal") * Speed;
    //    _moveVector.z = Input.GetAxis("Vertical") * Speed;
    //    var inputHoriontal = Input.GetAxis("Horizontal");
    //    var inputVertical = Input.GetAxis("Vertical");
    //    var inputDirection = new Vector2(inputHoriontal, inputVertical);

    //    return inputDirection;
    //}

    protected virtual void Move(/*Vector2 inputDirection*/)
    {
        //Transform.position += new Vector3(inputDirection.x, 0f, inputDirection.y) * (Speed * Time.deltaTime);
        if (_moveVector.x != 0 || _moveVector.z != 0)
        {
            Animation.SetBool(Constantes.StrMove, true);
        }
        else
        {
            Animation.SetBool(Constantes.StrMove, false);
            Fsm.SetState<FsmStateIdle>();
        }

        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * (Speed * Time.deltaTime);
        _moveVector.z = Input.GetAxis("Vertical") * (Speed * Time.deltaTime);

        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(Transform.forward, _moveVector, Speed, _maximumMagnitudeDelta);
            Transform.rotation = Quaternion.LookRotation(direct);
        }

        _moveVector.y = _gravityForce;
        Controller.Move(_moveVector * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!Controller.isGrounded)
        {
            _gravityForce -= _forceOfWeightlessness * Time.deltaTime;
        }
        else
        {
            _gravityForce = _forceOfAttraction;
        }
    }
}