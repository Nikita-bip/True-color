using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebirth : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Movement movement))
        {
            movement.transform.position = _spawnPoint.transform.position;
            Debug.Log("w12321");
        }
    }
}
