using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToPlace : Interactable
{
    public UnityEvent Remove;

    [SerializeField]
    private List<Placeable> placeables;
    [SerializeField]
    private Placeable placedItem = null;

    public override void OnInteract()
    {
        if (placedItem == null)
            return;

        onInteract?.Invoke();
        //placedItem = null;
    }

    public bool Interaction(Placeable placeable)
    {
        //checking if the holding item matches the required item
        if (placeables.Contains(placeable))
        {
            placeable.Place.Invoke();
            placedItem = placeable;
            placeable.Remove.AddListener(Remove.Invoke);
            placeable.Remove.AddListener(() => placedItem = null);
            placeable.Remove.AddListener(placeable.Remove.RemoveAllListeners);
            OnInteract();
            return true;
        }

        return false;
    }
}
