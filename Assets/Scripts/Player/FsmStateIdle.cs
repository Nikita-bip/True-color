using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateIdle : FsmState
{
    protected readonly Animator Animation;

    public FsmStateIdle(Fsm fsm, Animator animator) : base(fsm, animator) { }

    public override void Enter()
    {
        Debug.Log("Idle state [ENTER]");
    }

    public override void Exit()
    {
        Debug.Log("Idle state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log("Idle state [UPDATE]");

        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            Fsm.SetState<FsmStateMovement>();
        }

        if (Input.GetAxis("Horizontal") == 0f || Input.GetAxis("Vertical") == 0f)
        {

        }
    }
}
