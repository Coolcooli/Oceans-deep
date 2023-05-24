using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenLocationRemapper : MonoBehaviour
{
    [SerializeField] private Transform targetObject;

    private const float minValue = -.71f;
    private const float maxValue = .71f;

    private const float maxX = 100;
    private const float maxZ = 100;

    private void FixedUpdate()
    {
        RemapMonsterLocation();
    }

    private void Update()
    {
        RemapMonsterLocation();
    }

    /// <summary>
    /// This function remaps the location of the monster to the correct position on the screen.
    /// </summary>
    private void RemapMonsterLocation()
    {
        float targetX = MathAdditions.Remap(targetObject.position.x, -maxX, maxX, minValue, maxValue);  
        float targetY = MathAdditions.Remap(targetObject.position.z, -maxZ, maxZ, minValue, maxValue);

        transform.localPosition = new Vector3(targetX, targetY, transform.localPosition.z);
    }
}
