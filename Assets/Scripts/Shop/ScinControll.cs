using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScinControll : MonoBehaviour
{
    [SerializeField] private int _scinIndex = 0;
    [SerializeField] private GameObject[] _scins;


    void Start()
    {
        _scinIndex = PlayerPrefs.GetInt(Constantes.StrSelectedScin, 0);

        foreach (GameObject scin in _scins)
            scin.SetActive(false);


        _scins[_scinIndex].SetActive(true);
    }
}
