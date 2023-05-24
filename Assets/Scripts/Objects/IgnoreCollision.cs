using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField]
    private bool ignore = true;

    [SerializeField]
    private Collider[] ignoredColliders;

    // Start is called before the first frame update
    void Start()
    {
        Collider ownCollider = GetComponent<Collider>();
        foreach (Collider collider in ignoredColliders)
        {
            Physics.IgnoreCollision(collider, ownCollider, ignore);
        }
    }
}
