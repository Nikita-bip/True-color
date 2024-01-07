using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateMovement : FsmState
{
    protected readonly Transform Transform;
    protected readonly float Speed;
    protected readonly Animator Animation;

    public FsmStateMovement(Fsm fsm, Animator animator, Transform transform, float speed) : base(fsm, animator)
    {
        Transform = transform;
        Speed = speed;
        Animation = animator;
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

        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
        {
            Animation.SetBool(Constantes.StrMove, false);
            Fsm.SetState<FsmStateIdle>();
        }
        else
        {
            
        }

        Animation.SetBool(Constantes.StrMove, true);
        Move(inputDirection);
    }

    protected Vector2 ReadInput()
    {
        var inputHoriontal = Input.GetAxis("Horizontal");
        var inputVertical = Input.GetAxis("Vertical");
        var inputDirection = new Vector2(inputHoriontal, inputVertical);

        return inputDirection;
    }

    protected virtual void Move(Vector2 inputDirection)
    {
        Transform.position += new Vector3(inputDirection.x, 0f, inputDirection.y) * (Speed * Time.deltaTime);
    }
}
