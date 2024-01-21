using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FsmExample : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;

    private Fsm _fsm;
    private float _speed = 2f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _fsm = new Fsm();

        _fsm.AddState(new FsmStateIdle(_fsm, _animator));
        _fsm.AddState(new FsmStateMovement(_fsm, _animator, transform, _speed, _characterController));
        _fsm.AddState(new FsmStateMovementJoystic(_fsm, _animator, transform, _speed));
        _fsm.AddState(new FsmStateDance(_fsm, _animator));

        _fsm.SetState<FsmStateIdle>();
    }

    private void Update()
    {
        _fsm.Update();
    }
}
