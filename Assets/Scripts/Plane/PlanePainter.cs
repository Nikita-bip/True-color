using UnityEngine;

public class PlanePainter : MonoBehaviour
{
    [SerializeField] private Material[] _colors;
    [SerializeField] private PlaneSwither _spawnPlane;

    private int _countOfPlane;
    private int _countOfColors;
    private int _counter = 0;
    private int _indexOfColor = 0;

    private void Start()
    {
        _countOfPlane = _spawnPlane.AllPlanes.Length;
        _countOfColors = _colors.Length;
    }

    public void Paint()
    {
        int countOfPlanesCertainColor = _countOfPlane / _countOfColors;

        for (int i = 0; i < _countOfPlane; i++)
        {
            _spawnPlane.AllPlanes[i].GetComponent<MeshRenderer>().material = _colors[_indexOfColor];
            _counter++;

            if (_counter >= countOfPlanesCertainColor)
            {
                _counter = 0;
                _indexOfColor++;
            }

            if (_indexOfColor >= _colors.Length)
            {
                _indexOfColor = 0;
            }
        }
    }
}
