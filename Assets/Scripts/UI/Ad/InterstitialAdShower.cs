using Agava.YandexGames;

public class InterstitialAdShower : AdShower
{
    public override void Show()
    {
        InterstitialAd.Show(OnOpenCallbackInLevel, OnCloseCallbackInLevel, OnErrorCallback);
    }
}
