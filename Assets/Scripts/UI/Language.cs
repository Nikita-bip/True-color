using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    [SerializeField] private Sprite _mainImage;
    [SerializeField] private Sprite[] _languages;
    [SerializeField] private Button _button;

    private void Start()
    {
        for (int i = 0; i < _languages.Length; i++)
        {
            int index = i;
            _button.onClick.AddListener(() => changeMainImage(index));
        }
    }

    private void changeMainImage(int imageIndex)
    {
        _button.GetComponent<Image>().sprite = _languages[imageIndex];
    }
}
