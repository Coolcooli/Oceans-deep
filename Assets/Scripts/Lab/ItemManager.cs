using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    public UnityEvent enoughItems;

    protected int currentItems = 0;

    [SerializeField]
    protected int maxItems;

    public void AddItem()
    {
        currentItems++;
        CheckItemAmount();
    }

    public void RemoveItem()
    {
        currentItems--;
    }

    private void CheckItemAmount()
    {
        if (currentItems >= maxItems)
        {
            enoughItems?.Invoke();
        }
    }
}
