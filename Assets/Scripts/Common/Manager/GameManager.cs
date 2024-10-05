using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private event EventHandler OnUpdate;

    private void Update()
    {
        OnUpdate?.Invoke(this, EventArgs.Empty);
    }

    public void AddUpdateListener(EventHandler handler)
    {
        OnUpdate += handler;
    }

    public void RemoveUpdateListener(EventHandler handler)
    {
        OnUpdate -= handler;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
