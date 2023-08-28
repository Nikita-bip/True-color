using UnityEngine;

public class MoneyButton : MonoBehaviour
{
    public void Plus()
    {
        PlayerPrefs.SetInt(Constantes.StrCountMoney, PlayerPrefs.GetInt(Constantes.StrCountMoney) + 300);
    }
}
