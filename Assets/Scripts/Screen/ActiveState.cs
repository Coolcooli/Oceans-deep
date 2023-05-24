using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveState : MonoBehaviour
{
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public void SetActiveState(bool newState)
    {
        mat.SetFloat("_IsActive", Convert.ToInt32(newState));
    }
}
