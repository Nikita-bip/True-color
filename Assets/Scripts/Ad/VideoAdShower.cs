using Agava.YandexGames;

namespace Assets.Scripts.Ad
{
    public class VideoAdShower : AdShower
    {
        public override void Show()
        {
            VideoAd.Show(OnOpenCallback, OnCloseCallBackReward, OnCloseCallback);
        }
    }
}