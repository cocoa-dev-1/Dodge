using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private PlayerData playerData;

    private int health;
    private float speed;
    public float Speed => speed;

    private void Awake()
    {
        Reset();
    }


    private void Reset()
    {
        health = playerData.Health;
        speed = playerData.Speed;
    }
}
