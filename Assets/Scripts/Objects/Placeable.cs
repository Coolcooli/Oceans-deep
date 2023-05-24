using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Placeable : Pickupable
{
    public UnityEvent Place;
    public UnityEvent Remove;

    public override void Pickup(GameObject player)
    {
        base.Pickup(player);

        if (IsLocked) return;

        Remove?.Invoke();
    }
}
