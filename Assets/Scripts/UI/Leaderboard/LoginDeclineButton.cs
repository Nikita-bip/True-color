using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class LoginDeclineButton : MonoBehaviour
    {
        [SerializeField] private LoginPanel _loginPanel;

        public void OnClick()
        {
            Decline();
        }

        private void Decline()
        {
            _loginPanel.gameObject.SetActive(false);
        }
    }
}