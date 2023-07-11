using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private CharacterController[] _characterControllers;
    [SerializeField] private InterstitialAdShower _interstitialAdShower;

    private const string _adv = nameof(Adv);
    private Vector3 _changesAngles = new Vector3(0f, 180f, 0f);

    [HideInInspector] public bool IsFinished = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Movement movement))
        {
            foreach (var characterController in _characterControllers)
            {
                characterController.transform.eulerAngles = _changesAngles;
            }

            _finishPanel.SetActive(true);
            Invoke(_adv, 0.2f);
            IsFinished = true;
        }
    }

    private void Adv()
    {
        _interstitialAdShower.Show();
    }
}
