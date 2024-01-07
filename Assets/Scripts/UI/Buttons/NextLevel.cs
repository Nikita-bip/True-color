using Assets.Scripts.Ad;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField] private InterstitialAdShower _interstitialAdShower;

        public void OnClick()
        {
            _interstitialAdShower.Show();
        }
    }
}