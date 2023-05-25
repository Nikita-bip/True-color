using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LosePanel : MonoBehaviour
{
    [SerializeField] private AudioSource _myFX;
    [SerializeField] private AudioClip _lose;
    [SerializeField] private Movement _movement;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _switcher;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Dead.IsDead == true)
        {
            _animator.SetBool(Constantes.StrFinish, true);
        }
    }

    private void OnEnable()
    {
        _movement.enabled = false;
        _switcher.SetActive(false);
        _joystick.SetActive(false);
        _myFX.PlayOneShot(_lose);
    }
}
