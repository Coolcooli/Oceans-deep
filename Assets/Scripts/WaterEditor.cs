using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class WaterEditor : MonoBehaviour
{
    [SerializeField]
    private WaterSurface surface;

    public void SetCaustic(bool value)
    {
        surface.caustics = value;
    }
}
