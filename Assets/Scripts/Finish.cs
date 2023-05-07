using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private float _animationSpeed;

    private Movement _player;

    public static int CountLevel { get; private set; }
    [HideInInspector] public bool IsFinished = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Movement player))
        {
            _joystick.SetActive(false);
            _finishPanel.SetActive(true);
            IsFinished = true;
            player.enabled = false;
            SaveScore();
        }
    }

    private void ClosePanel()
    {
        _joystick.SetActive(true);
        _finishPanel.SetActive(false);
        _player.enabled = true;
    }

    public static void SaveScore()
    {
        CountLevel++;

        PlayerPrefs.SetInt(Constantes.StrCountLevel, PlayerPrefs.GetInt(Constantes.StrCountLevel) + CountLevel);
        PlayerPrefs.SetInt(Constantes.StrCountMoney, PlayerPrefs.GetInt(Constantes.StrCountMoney) + 50);


        PlayerPrefs.Save();

        Leaderboard.AddPlayer(CountLevel);
    }
}
