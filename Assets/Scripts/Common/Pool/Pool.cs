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
    [SerializeField] private GameObject prefab;
    public GameObject Prefab => prefab;
    [SerializeField] private Transform parent = null;

    private readonly Stack<GameObject> pools = new();

    public void Initialize()
    {
        for (int i = 0; i < initialSize; i++)
        {
            var obj = CreateNewObject();
            obj.SetActive(false);
            pools.Push(obj);
        }
    }

    public GameObject GetOne()
    {
        GameObject obj = GetObjectFromPool();
        obj.SetActive(true);

        return obj;
    }

    public T GetOne<T>() where T : Component
    {
        GameObject obj = GetObjectFromPool();
        obj.SetActive(true);

        if (obj.TryGetComponent(out T component))
        {
            return component;
        }
        else
        {
            obj.SetActive(false);
            throw new System.Exception("Component not found");
        }
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pools.Push(obj);
    }

    private GameObject GetObjectFromPool()
    {
        if (pools.Count == 0)
        {
            return CreateNewObject();
        }

        return pools.Pop();
    }

    private GameObject CreateNewObject()
    {
        if (parent == null)
        {
            return Object.Instantiate(prefab);
        }

        return Object.Instantiate(prefab, parent);
    }

    public static Pool Create(GameObject prefab)
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
