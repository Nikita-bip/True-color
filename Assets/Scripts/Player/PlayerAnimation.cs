using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private int _dancingkHash = Animator.StringToHash("Dance");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Finish>(out Finish _finish))
        {
            _animator.SetInteger(_dancingkHash, 1);
        }
    }
}
