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
}
