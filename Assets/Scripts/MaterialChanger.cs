using System;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField]
    private Material newMaterial;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void AddNewMaterial()
    {
        Material[] materials = meshRenderer.materials;
        Material[] newMaterials = new Material[materials.Length + 1];
        for (int i = 0; i < materials.Length; i++)
        {
            newMaterials[i] = materials[i];
        }
        newMaterials[^1] = newMaterial;
        meshRenderer.materials = newMaterials;
    }

    public void RemoveNewMaterial()
    {
        Material[] materials = { meshRenderer.materials[0] };
        meshRenderer.materials = materials;
    }
}