using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionEditor : MonoBehaviour
{
    [SerializeField]
    private Material material;

    private float originValue = 0;

    private void Start()
    {
        originValue = material.GetFloat("_EmissiveIntensity");
    }

    public void MaterialEmission(float amount)
    {
        material.SetFloat("_EmissiveIntensity", amount);
    }

    public void Reset()
    {
        material.SetFloat("_EmissiveIntensity", originValue);
    }

    private void OnApplicationQuit()
    {
        Reset();
    }
}
