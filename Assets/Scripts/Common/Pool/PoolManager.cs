using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] private Pool[] pools;

    private void Start()
    {
        foreach (Pool pool in pools)
        {
            pool.Initialize();
        }
    }

    public T GetOne<T>() where T : Component, IPoolable
    {
        foreach (Pool pool in pools)
        {
            if (pool.Prefab.GetType() == typeof(T))
            {
                return pool.GetOne<T>();
            }
        }

        return null;
    }

    public T GetOne<T>(string name) where T : Component, IPoolable
    {
        foreach (Pool pool in pools)
        {
            if (pool.Name == name && pool.Prefab.GetType() == typeof(T))
            {
                return pool.GetOne<T>();
            }
        }

        return null;
    }

    public void Return<T>(T obj) where T : Component, IPoolable
    {
        foreach (Pool pool in pools)
        {
            if (pool.Prefab.GetType() == typeof(T))
            {
                pool.Return(obj);
                return;
            }
        }
    }
}
