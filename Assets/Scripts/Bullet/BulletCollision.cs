using UnityEngine;

public class BulletCollision : MonoBehaviour
{
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

        if (other.gameObject.TryGetComponent(out BInteraction interaction))
        {
            interaction.Interact(gameObject);
        }

        PoolManager.Instance.Return("Bullet", gameObject);
    }
}
