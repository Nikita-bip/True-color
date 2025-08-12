using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    internal static float height;

    protected virtual void Awake()
    {
        Close();
    }
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

    protected void OnButtonClicked(UnityAction action)
    {
        action?.Invoke();
    }
}
