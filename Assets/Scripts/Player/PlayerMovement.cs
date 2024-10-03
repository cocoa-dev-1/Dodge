using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BMovement
{
    private float speed;
    private Vector3 direction = Vector3.zero;

    public void Start()
    {
        speed = PlayerManager.Instance.Speed;
        GameManager.Instance.AddUpdateListener(OnUpdate);
    }

    public override void Move(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnUpdate(object sender, System.EventArgs e)
    {
        if (direction == Vector3.zero) return;
        transform.position += speed * Time.deltaTime * direction.normalized;
    }
}
