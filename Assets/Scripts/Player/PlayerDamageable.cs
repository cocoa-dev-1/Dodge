using UnityEngine;

public class PlayerDamageable : BDamageable
{
    public override void TakeDamage(int damage)
    {
        PlayerManager.Instance.TakeDamage(damage);
    }
}
