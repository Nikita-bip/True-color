using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public class ActiveStateFrame : MonoBehaviour
    {
        public void TurnOn()
        {
            gameObject.SetActive(true);
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}