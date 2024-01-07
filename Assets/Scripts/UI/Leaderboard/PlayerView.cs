using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerNumber;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _playerScore;

        private int _number;
        private string _name;
        private int _score;
        private bool _isUser;
        private ActiveStateFrame _activeStateFrame;

        public void Init(int playerNumber, string playerName, int playerScore, bool isUser = false)
        {
            _number = playerNumber;
            _name = playerName;
            _score = playerScore;
            _isUser = isUser;
        }

        public void Render()
        {
            _playerNumber.text = _number.ToString();
            _playerName.text = _name;
            _playerScore.text = _score.ToString();

            if (_isUser)
                _activeStateFrame.TurnOn();
            else
                _activeStateFrame.TurnOff();
        }
    }
}