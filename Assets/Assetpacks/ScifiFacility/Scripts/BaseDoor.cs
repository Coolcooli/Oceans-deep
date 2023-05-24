using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDoor : MonoBehaviour
{
    [SerializeField]
    protected List<Animation> wings;

    [SerializeField]
    private bool isLocked;
    public bool IsLocked { get { return isLocked; } }

    [SerializeField]
    private AudioSource doorSound;

    private bool isOpen = false;

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.tag);
        if (isLocked || isOpen || !(c.CompareTag("Player") || c.CompareTag("Lizard"))) return;
        OpenDoor();
    }

    void OnTriggerExit(Collider c)
    {
        if (isLocked || !isOpen || !c.CompareTag("Player")) return;
        CloseDoor();
    }

    protected virtual void OpenDoor()
    {
        doorSound.Play();
        isOpen = true;
    }

    protected virtual void CloseDoor()
    {
        doorSound.Play();
        isOpen = false;
    }

    public virtual void UnlockDoor()
    {
        isLocked = false;
    }

    public virtual void lockDoor(){
        isLocked = true;
    }

    public virtual void ToggleLock()
    {
        isLocked = !isLocked;
    }
}
