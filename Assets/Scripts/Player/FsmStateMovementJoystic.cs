using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateMovementJoystic : FsmState
{
    protected readonly Transform Transform;
    protected readonly float Speed;

    public FsmStateMovementJoystic(Fsm fsm, Animator animator, Transform transform, float speed) : base(fsm, animator)
    {
        Transform = transform;
        Speed = speed;
    }
}
