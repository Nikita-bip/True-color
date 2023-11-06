using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Particle : MonoBehaviour
{
    [SerializeField] private GameObject _effectWater;
    [SerializeField] private GameObject _effectFinishFirst;
    [SerializeField] private GameObject _effectFinishSecond;
    [SerializeField] private GameObject _spawnPointFinishParticle;

    private Movement _movement;
    private Vector3 _changesHeight = new Vector3(0f, 0.57f, 0f);

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Dead dead))
        {
            Instantiate(_effectWater, _movement.transform.position + _changesHeight, Quaternion.identity);
        }

        if (collider.TryGetComponent(out Finish finish))
        {
            Finish(_effectFinishFirst);
            Finish(_effectFinishSecond);
        }
    }

    private void Finish(GameObject effect)
    {
        Instantiate(effect, _spawnPointFinishParticle.transform.position, Quaternion.identity);
    }
}