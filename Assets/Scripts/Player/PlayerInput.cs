using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// [RequireComponent(typeof(BMovement))]
public class PlayerInput : BInput
{
    private BMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<BMovement>();
    }

    public override void Input(KeyCode key)
    {
        movement.Move(Vector3.up);
    }
}
