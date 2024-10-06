using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private HumanData playerData;

    private int health;
    public int Health => health;

    private bool isDead = false;
    public bool IsDead => isDead;

    private float speed;
    public float Speed => speed;

    private Vector3 position = Vector3.zero;
    public Vector3 Position => position;

    private void Awake()
    {
        Reset();
    }

    public void UpdatePlayerPosition(Vector3 position)
    {
        this.position = position;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        isDead = true;
        GameManager.Instance.GameOver();
    }

    private void Reset()
    {
        health = playerData.Health;
        speed = playerData.Speed;
    }
}
