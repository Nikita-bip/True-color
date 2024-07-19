using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class FinishDance : MonoBehaviour
    {
        private Animator _animator;
        private int _danceNumber = 2;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Finish._onFinished += Dance;
        }

        private void OnDisable()
        {
            Finish._onFinished -= Dance;
        }

        private void Dance()
        {
            _animator.SetInteger(Constants.StrDance, _danceNumber);
        }
    }
}