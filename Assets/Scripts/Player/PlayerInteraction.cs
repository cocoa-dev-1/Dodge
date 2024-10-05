using UnityEngine;

public class PlayerInteraction : BInteraction
{
    public override void Interact(GameObject other)
    {
        if (other.CompareTag("Bullet"))
        {
            PlayerManager.Instance.Dead();
        }
    }
}
