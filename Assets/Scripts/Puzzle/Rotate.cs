using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private int rotationDegrees;

    private float rotation;

    private float endRotation;

    private bool isRotating = false;

    private void Awake()
    {
        rotation = transform.localEulerAngles.z;
        endRotation = rotation + rotationDegrees;
    }

    private void FixedUpdate()
    {
        if (rotation > endRotation) isRotating = false;

        if (!isRotating) return;

        rotation += 3;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotation);
    }

    public void StartRotation()
    {
        isRotating = true;
    }
}
