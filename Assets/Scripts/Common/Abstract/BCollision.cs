using UnityEngine;

public abstract class BCollision : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BInteraction interaction))
        {
            interaction.Interact(gameObject);
        }
    }
}
