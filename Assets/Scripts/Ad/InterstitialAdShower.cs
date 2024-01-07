using Agava.YandexGames;

namespace Assets.Scripts.Ad
{
    public class InterstitialAdShower : AdShower
    {
        public override void Show()
        {
            InterstitialAd.Show(OnOpenCallbackInLevel, OnCloseCallbackInLevel, OnErrorCallback);
        }
    }
}