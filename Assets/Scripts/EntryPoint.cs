using Assets.Scripts.UI.UIShop;
using System.Collections;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Skins _skins;

    private void Awake()
    {
        _playerData.Init();
        StartCoroutine(WaitForLoadPlayerData());
    }

    private void OnDestroy()
    {
        _playerData.SaveData();
    }

    private IEnumerator WaitForLoadPlayerData()
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        while (_playerData.IsDataLoaded == false)
        {
            yield return waitForEndOfFrame;
        }

        ApplyGameSettings();
    }

    private void ApplyGameSettings()
    {
        _skins.Init();
    }
}