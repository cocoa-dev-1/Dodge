using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : BInput
{
    private BMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<BMovement>();
    }

    void OnMove(InputValue value)
    {
        if (movement == null) return;

        Vector2 direction = value.Get<Vector2>();

        movement.Move(new Vector3(direction.x, 0, direction.y));
    }
}
