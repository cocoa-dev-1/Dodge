using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            return;
        }
        else if (other.CompareTag("Wall"))
        {
            PoolManager.Instance.Return("Bullet", gameObject);
            return;
        }

        if (other.gameObject.TryGetComponent(out BDamageable damageable))
        {
            damageable.TakeDamage(bulletData.Damage);
        }

        PoolManager.Instance.Return("Bullet", gameObject);
    }
}
