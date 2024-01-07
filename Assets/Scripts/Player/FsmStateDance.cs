using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateDance : FsmState
{
    public FsmStateDance(Fsm fsm, Animator animator) : base(fsm, animator) { }

    public override void Enter()
    {
        Debug.Log($"Dance ({this.GetType().Name}) state [ENTER]");
    }

    public override void Update()
    {
        Debug.Log($"Dance ({this.GetType().Name}) state [UPDATE]");

        //_animator.SetInteger(Constantes.StrDance, _danceNumber);
    }
}
