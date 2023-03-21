using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _finishPanel.SetActive(true);
            _player.enabled = false;
        }
    }

    private void ClosePanel()
    {
        _finishPanel.SetActive(false);
        _player.enabled = true;
    }
}
