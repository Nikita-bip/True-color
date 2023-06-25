using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private InterstitialAdShower _interstitialAdShower;

    private const string _adv = nameof(Adv);
    private Vector3 _changesAngles = new Vector3(0f, 180f, 0f);

    [HideInInspector] public bool IsFinished = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Movement movement))
        {
            _finishPanel.SetActive(true);
            Invoke(_adv, 0.2f);
            IsFinished = true;
            _characterController.transform.eulerAngles = _changesAngles;
        }
    }

    private void Adv()
    {
        _interstitialAdShower.Show();
    }
}
