using System;
using UnityEngine;

public interface IPoolable
{
    void OnSpawn();
    void OnDespawn();
}