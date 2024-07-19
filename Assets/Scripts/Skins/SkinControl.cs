using UnityEngine;

namespace Assets.Scripts.Skins
{
    public class SkinControl : MonoBehaviour
    {
        [SerializeField] private int _skinIndex = 0;
        [SerializeField] private GameObject[] _skins;

        private void Start()
        {
            _skinIndex = PlayerPrefs.GetInt(Constants.StrSelectedSkin, 0);

            foreach (GameObject skin in _skins)
            {
                skin.SetActive(false);
            }

            _skins[_skinIndex].SetActive(true);
        }
    }
}