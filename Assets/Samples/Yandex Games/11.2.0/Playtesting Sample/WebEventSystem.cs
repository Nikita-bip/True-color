using UnityEngine;
using UnityEngine.EventSystems;

namespace Agava.YandexGames.Samples
{
    public class WebEventSystem : EventSystem
    {
        protected override void OnApplicationFocus(bool hasFocus)
        {
            base.OnApplicationFocus(true);
            Time.timeScale = hasFocus ? 1f : 0f;

            AudioListener.pause = !hasFocus;
            AudioListener.volume = hasFocus ? 1f : 0f;
        }
    }
}
