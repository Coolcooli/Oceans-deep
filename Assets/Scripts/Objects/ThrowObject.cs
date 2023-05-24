using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    private Rigidbody[] rb;

    private void Awake()
    {
        rb = GetComponentsInChildren<Rigidbody>();
    }

    public void ThrowObjects()
    {
        foreach (Rigidbody body in rb)
        {
            Vector3 force = transform.up;
        }
    }
}
