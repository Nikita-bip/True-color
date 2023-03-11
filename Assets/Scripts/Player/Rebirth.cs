using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebirth : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<PlayerInput>(out PlayerInput playerInput))
        {
            playerInput.transform.position = _spawnPoint.transform.position;
        }
    }
}
