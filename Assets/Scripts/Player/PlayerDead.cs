using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerDead : MonoBehaviour
    {
        [HideInInspector] public bool IsDead = false;
        [SerializeField] private LosePanel _losePanel;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out CharacterController characterController))
            {
                IsDead = true;
                _losePanel.gameObject.SetActive(true);
            }
        }
    }
}