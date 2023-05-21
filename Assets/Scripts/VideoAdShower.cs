using Agava.YandexGames;

public class VideoAdShower : AdShower
{
    public override void Show()
    {
        VideoAd.Show(OnOpenCallBack, onCloseCallback: OnCloseCallBack);
    }
}
