using UnityEngine;

namespace Assets.Scripts.Plane
{
    public class PlaneSwither : MonoBehaviour
    {
        [SerializeField] private GameObject[] _plane;
        [SerializeField] private Material[] _selectColor;
        [SerializeField] private Timer _timer;
        [SerializeField] private PlanePainter _planePainter;

        private int _selectedColorNumber = 0;
        private bool _flag = true;

        [HideInInspector] public GameObject[] AllPlanes;

        private void Awake()
        {
            AllPlanes = _plane;
        }

        private void Start()
        {
            _planePainter.Paint();
        }

        private void OnEnable()
        {
            _timer.IsZero += Switch;
            _timer.Restarting += IncreaseColorNumber;
        }

        private void OnDisable()
        {
            _timer.IsZero -= Switch;
            _timer.Restarting -= IncreaseColorNumber;
        }

        private void Switch(bool zero)
        {
            for (int i = 0; i < _plane.Length; i++)
            {
                if (zero == true)
                {
                    if (_plane[i].GetComponent<MeshRenderer>().sharedMaterial == _selectColor[_selectedColorNumber])
                    {
                        _plane[i].SetActive(true);
                    }
                    else
                    {
                        _plane[i].SetActive(false);
                    }
                }
                else
                {
                    _plane[i].SetActive(true);
                }
            }
        }

        private void IncreaseColorNumber(bool restart)
        {
            if (restart == true & _flag == true)
            {
                _selectedColorNumber++;
                _flag = false;

                if (_selectedColorNumber >= _selectColor.Length)
                {
                    _selectedColorNumber = 0;
                }
            }

            if (restart == false)
            {
                _flag = true;
            }
        }
    }
}