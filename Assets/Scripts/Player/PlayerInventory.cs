using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    private const int inventorySize = 3;
    private Pickupable[] inventory = new Pickupable[inventorySize];

    private int holding = 0;
    public Pickupable Holding { get { return inventory[holding]; } }

    //timer to set a delay between item switching
    private const int scrollTime = 20;
    private int scrollTimer;

    private void Awake()
    {
        scrollTimer = scrollTime;
    }

    private void FixedUpdate()
    {
        if (scrollTimer <= scrollTime)
            scrollTimer++;
    }

    /// <summary>
    /// Adds an item to the inventory
    /// </summary>
    /// <param name="item">the item that needs to be added</param>
    public void Add(Pickupable item)
    {
        for (int slot = 0; slot < inventorySize; slot++)
        {
            if (inventory[slot] == null)
            {
                item.Pickup(this.gameObject);
                inventory[slot] = item;
                if (slot != holding)
                {
                    item.gameObject.SetActive(false);
                }
                break;
            }
        }
    }

    /// <summary>
    /// drops the item the player is currently holding
    /// </summary>
    public void Drop()
    {
        if (inventory[holding] == null)
            return;
        inventory[holding].Drop();
        inventory[holding] = null;
    }

    /// <summary>
    /// switches to a different slot of the inventory
    /// </summary>
    /// <param name="slot">the slot the player switches to</param>
    public void Switch(int slot)
    {
        if (slot >= inventorySize || slot < 0 || slot == holding)
            return;

        //hides current item
        if (inventory[holding] != null)
            inventory[holding].gameObject.SetActive(false);
        //shows new item
        if (inventory[slot] != null)
            inventory[slot].gameObject.SetActive(true);
        holding = slot;

    }

    public void UseItem()
    {
        inventory[holding].DoDestroy();
        inventory[holding] = null;
    }

    /// <summary>
    /// calculates if input is negative and then switches to the next/previous item
    /// </summary>
    /// <param name="context">the input</param>
    public void OnScroll(InputAction.CallbackContext context)
    {
        if (scrollTimer < scrollTime)//cooldown check
            return;
        scrollTimer = 0;

        int nextValue = holding;
        nextValue += context.ReadValue<float>() > 0 ? 1 : -1;
        //loop
        if (nextValue >= inventorySize)
            nextValue = 0;
        if (nextValue < 0)
            nextValue = inventorySize - 1;

        Switch(nextValue);
    }
}
