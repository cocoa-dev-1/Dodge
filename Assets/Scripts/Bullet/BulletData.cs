using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Bullet/BulletData", order = 1)]
public class BulletData : ScriptableObject
{
    public int Damage = 1;
    public float Speed = 8.0f;
}
