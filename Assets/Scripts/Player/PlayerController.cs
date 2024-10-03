using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BInput))]
public class PlayerController : MonoBehaviour
{
    private BInput input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<BInput>();

        Debug.Log(input);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
