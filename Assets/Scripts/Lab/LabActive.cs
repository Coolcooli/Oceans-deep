using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LabActive : MonoBehaviour
{
    private bool isActive = false;
    public bool IsActive { get { return isActive; } set { isActive = value; onActiveChanged.Invoke(isActive); } }

    public UnityEvent<bool> onActiveChanged;

    public void ActivateLab()
    {
        IsActive = true;
    }
}
