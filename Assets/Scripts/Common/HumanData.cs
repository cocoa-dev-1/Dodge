using UnityEngine;

[CreateAssetMenu(fileName = "HumanData", menuName = "Human/HumanData", order = 1)]
public class HumanData : ScriptableObject
{
    public int Health = 10;
    public float Speed = 5.0f;
}
