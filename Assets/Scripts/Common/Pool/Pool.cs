using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField] private string name;
    public string Name => name;
    [SerializeField] private int initialSize = 10;
    [SerializeField] private Component prefab;
    public Component Prefab => prefab;
    [SerializeField] private Transform parent = null;

    private readonly Stack<Component> pools = new();

    public void Initialize()
    {
        for (int i = 0; i < initialSize; i++)
        {
            Component obj = Object.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            pools.Push(obj);
        }
    }

    public T GetOne<T>() where T : Component, IPoolable
    {
        if (pools.Count == 0)
        {
            Component obj = Object.Instantiate(prefab, parent);
            return obj as T;
        }

        Component pooledObject = pools.Pop();
        pooledObject.gameObject.SetActive(true);

        return pooledObject as T;
    }

    public void Return<T>(T obj) where T : Component, IPoolable
    {
        obj.gameObject.SetActive(false);
        pools.Push(obj);
    }

    public static Pool Create(Component prefab)
    {
        Pool pool = new()
        {
            name = prefab.name,
            prefab = prefab,
        };
        pool.Initialize();

        return pool;
    }
}
