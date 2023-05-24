using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class TeleportCheat : MonoBehaviour
{
    public UnityEvent cheatEvent;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private List<Transform> points = new();

    private bool cheat = false;
        
    public void TeleportTo(CallbackContext context)
    {
        if(context.started)
        {
            playerMovement.enabled = false;
            characterController.enabled = false;
            cheat = true;
        }

        if(context.performed)
        {
            int numKeyValue;
            int.TryParse(context.control.name, out numKeyValue);

            if (numKeyValue == 1)
                playerMovement.GetComponent<Player>().IsInWater = true;

            gameObject.transform.position = points[numKeyValue].position;
        }

        if(context.canceled)
        {
            playerMovement.enabled = true;
            characterController.enabled = true;
        }

        if(cheat)
        {
            cheatEvent?.Invoke();
        }

    }
}
