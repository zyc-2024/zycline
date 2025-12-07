using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGravity : MonoBehaviour
{
    private Vector3 gravity;

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "line")
        {
            gravity.x = 0;
            gravity.y = -9.81f;
            gravity.z = 0;

            Physics.gravity = gravity;
        }
    }
}