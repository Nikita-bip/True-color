using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private LosePanel _losePanel;

    [HideInInspector] public static bool IsDead = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out CharacterController characterController))
        {
            IsDead = true;
            _losePanel.gameObject.SetActive(true);
            _characterController.enabled = false;
        }
    }
}
