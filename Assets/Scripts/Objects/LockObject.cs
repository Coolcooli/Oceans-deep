using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Rigidbody objectToLock;

    public void Lock()
    {
        objectToLock.position = targetPosition.position;
        objectToLock.drag = 100000;
    }
}
