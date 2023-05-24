using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPolish : MonoBehaviour
{


    public void SetChildrenRigidbodiesKinematic()
    {
        Rigidbody[] childrenRigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in childrenRigidbodies)
        {
            rb.isKinematic = true;
        }
    }
}
