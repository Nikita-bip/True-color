#pragma warning disable

using System.Collections;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Agava.YandexGames.Samples
{
    public class Yandex : MonoBehaviour
    {
        private IEnumerator Init()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif

            // Always wait for it if invoking something immediately in the first scene.
            yield return Agava.YandexGames.YandexGamesSdk.Initialize();
        }

    }
}
