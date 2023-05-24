using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Interactable
{
    public bool locked;
    public bool canBeUnlocked;
    public Pickupable key;
    private MeshCollider col;

    void Start()
    {
        col = this.GetComponent<MeshCollider>();
        //checking if the door is locked
        if (locked)
        {
            col.isTrigger = false;
        }
    }

    /// <summary>
    /// Interact with the door to unlock it
    /// </summary>
    public bool Interaction(Pickupable key)
    {
        //checking if the door can be unlocked
        if (!canBeUnlocked)
        {
            //UI Text, door cant be unlocked
        }

        //check if door is locked and can be unlocked
        if (locked)
        {
            //checking if the holding item matches the required item
            if (this.key == key)
            {
                col.isTrigger = true;
                locked = false;
                return true;
            }
            // TO DO: UI Text, not having the key
        }
        return false;
    }

    public override void OnInteract()
    {
        if (locked)
            return;
        base.OnInteract();
    }
}
