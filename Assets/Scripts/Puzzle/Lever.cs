using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour, IInteract
{
    public UnityEvent e;

    public void OnInteract()
    {
        e?.Invoke();
    }
}
