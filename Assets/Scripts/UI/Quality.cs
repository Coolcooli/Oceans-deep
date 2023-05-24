
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    public void OnApply()
    {
        Slider slider = GetComponent<Slider>();
        QualitySettings.SetQualityLevel(slider.value.ConvertTo<int>());
    }
}
