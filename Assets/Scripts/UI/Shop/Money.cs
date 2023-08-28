using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text _countOfMoney;

    private void Update()
    {
        _countOfMoney.text = PlayerPrefs.GetInt(Constantes.StrCountMoney).ToString();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 7fcba35c0f20af8c87af357ea4ab3ee4ccb24927
