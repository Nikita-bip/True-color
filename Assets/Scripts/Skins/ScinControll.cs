using UnityEngine;

namespace Assets.Scripts.Skins
{
    public class ScinControll : MonoBehaviour
    {
        [SerializeField] private int _scinIndex = 0;
        [SerializeField] private GameObject[] _scins;

        private void Start()
        {
            _scinIndex = PlayerPrefs.GetInt(Constantes.StrSelectedScin, 0);

            foreach (GameObject scin in _scins)
            {
                scin.SetActive(false);
            }

            _scins[_scinIndex].SetActive(true);
        }
    }
}