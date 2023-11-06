using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private InterstitialAdShower _interstitialAdShower;

    public void OnClick()
    {
        _interstitialAdShower.Show();
    }
}