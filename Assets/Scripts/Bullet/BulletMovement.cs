using UnityEngine;

public class BulletMovement : BMovement
{
    [SerializeField] private BulletData bulletData;

    private Vector3 direction = Vector3.zero;

    private void OnEnable()
    {
        GameManager.Instance.AddUpdateListener(OnUpdate);
    }

    private void OnDisable()
    {
        GameManager.Instance.RemoveUpdateListener(OnUpdate);
    }

    public override void Move(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnUpdate(object sender, System.EventArgs e)
    {
        if (direction == Vector3.zero) return;
        transform.position += bulletData.Speed * Time.deltaTime * direction.normalized;
    }
}
