using System;
using UnityEngine;

namespace Assets.Scripts.UI.Leaderboard
{
    public abstract class ScreenLeaderboard : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public virtual void Open()
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.blocksRaycasts = true;
        }

        public virtual void Close()
        {
            _canvasGroup.alpha = 0.0f;
            _canvasGroup.blocksRaycasts = false;
        }

        protected virtual void Awake()
        {
            Close();
        }

        protected void OnButtonClicked(Action action)
        {
            action?.Invoke();
        }
    }
}