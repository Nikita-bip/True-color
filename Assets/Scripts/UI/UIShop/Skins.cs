using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.UIShop
{
    public class Skins : MonoBehaviour
    {
        [SerializeField] private List<Character> _characters;

        public void Init()
        {
            PlayerCharacterName characterType = (PlayerCharacterName)PlayerData.Instance.SelectedCharacter;

            foreach (var character in _characters)
            {
                if (character.PlayerCharacterName == characterType)
                {
                    character.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}