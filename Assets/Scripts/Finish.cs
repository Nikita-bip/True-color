using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private float _animationSpeed;

    private Movement _player;
    [HideInInspector] public bool IsFinished = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Movement player))
        {
            _joystick.SetActive(false);
            _finishPanel.SetActive(true);
            IsFinished = true;
            player.enabled = false;
        }
    }

    private void ClosePanel()
    {
        _joystick.SetActive(true);
        _finishPanel.SetActive(false);
        _player.enabled = true;
    }
}
