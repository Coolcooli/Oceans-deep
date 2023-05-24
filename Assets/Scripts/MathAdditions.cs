using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathAdditions
{
    /// <summary>
    /// Remaps value from certain range to target range
    /// </summary>
    /// <param name="value">Value to be remapped</param>
    /// <param name="from1">Lower value of given parameter</param>
    /// <param name="from2">Upper value of given parameter</param>
    /// <param name="to1">Lower value of target</param>
    /// <param name="to2">Upper value of target</param>
    /// <returns></returns>
    public static float Remap(float value, float from1, float from2, float to1, float to2)
    {
        return to1 + (value - from1) * (to2 - to1) / (from2 - from1);
    }
}
