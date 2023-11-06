using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Shop _shop;

    public void OnClick()
    {
        _shop.gameObject.SetActive(true);
    }
}