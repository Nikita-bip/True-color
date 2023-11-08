using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private CharacterController[] _characterControllers;

    [HideInInspector] public bool IsFinished = false;

    private Vector3 _changesAngles = new Vector3(0f, 180f, 0f);

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Movement movement))
        {
            foreach (var characterController in _characterControllers)
            {
                characterController.transform.eulerAngles = _changesAngles;
            }

            _finishPanel.SetActive(true);
            IsFinished = true;
        }
    }
}
