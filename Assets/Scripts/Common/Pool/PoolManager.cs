using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField]
    private Pool[] pools;

    private void Start()
    {
        foreach (Pool pool in pools)
        {
            pool.Initialize();
        }
    }

    public GameObject GetOne(string name)
    {
        foreach (Pool pool in pools)
        {
            if (pool.Name == name)
            {
                return pool.GetOne();
            }
        }

        throw new System.Exception("Pool not found");
    }

    public T GetOne<T>(string name) where T : Component
    {
        foreach (Pool pool in pools)
        {
            if (pool.Name == name)
            {
                return pool.GetOne<T>();
            }
        }

        throw new System.Exception("Pool not found");
    }

    public void Return(string name, GameObject obj)
    {
        foreach (Pool pool in pools)
        {
            if (pool.Name == name)
            {
                pool.Return(obj);
                return;
            }
        }

        throw new System.Exception("Pool not found");
    }
}
