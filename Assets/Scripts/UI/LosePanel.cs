using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Animator))]
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private AudioSource _myFX;
        [SerializeField] private AudioClip _lose;
        [SerializeField] private Movement[] _movements;
        [SerializeField] private GameObject _joystick;
        [SerializeField] private GameObject _switcher;
        [SerializeField] private GameObject _color;
        [SerializeField] private GameObject _timer;
        [SerializeField] private PlayerDead _dead;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_dead.IsDead == true)
            {
                _animator.SetBool(Constants.StrFinish, true);
            }
        }

        private void OnEnable()
        {
            foreach (var movement in _movements)
            {
                movement.enabled = false;
            }

            _switcher.SetActive(false);
            _color.SetActive(false);
            _joystick.SetActive(false);
            _timer.SetActive(false);
            _myFX.PlayOneShot(_lose);
        }
    }
}