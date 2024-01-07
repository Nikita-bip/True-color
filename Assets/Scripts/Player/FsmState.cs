using UnityEngine;

public abstract class FsmState
{
    protected readonly Fsm Fsm;
    protected Animator Animator;

    public FsmState(Fsm fsm, Animator animator)
    {
        Fsm = fsm;
        Animator = animator;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
