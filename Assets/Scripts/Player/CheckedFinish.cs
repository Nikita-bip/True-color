using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CheckedFinish : MonoBehaviour
{
    private Animator _animator;
    private int _danceNumber = 2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Finish.IsFinished == true)
        {
            _animator.SetInteger(Constantes.StrDance, _danceNumber);
        }
    }
}
