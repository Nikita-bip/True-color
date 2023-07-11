using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private CharacterController[] _characterControllers;
    [SerializeField] private LosePanel _losePanel;

    [HideInInspector] public bool IsDead = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out CharacterController characterController))
        {
            IsDead = true;
            _losePanel.gameObject.SetActive(true);
        }
    }
}
