using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private PlayerCharacterName _playerCharacterName;

    public PlayerCharacterName PlayerCharacterName => _playerCharacterName;
}