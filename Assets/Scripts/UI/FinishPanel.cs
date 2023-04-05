using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FinishPanel : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_finish.IsFinished == true)
        {
            _animator.SetBool("Finish", true);
        }
    }
}
