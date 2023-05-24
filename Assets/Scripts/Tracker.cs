using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Material mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void Update()
    {
        mat.SetVector("_Position", new Vector2((target.position.x-(target.position.x/2)) / 100, (target.position.z-(target.position.z/2)) / 100));
    }
}
