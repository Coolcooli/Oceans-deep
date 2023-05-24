using System.Collections.Generic;
using UnityEngine;

public class Door_01 : MonoBehaviour
{
    [SerializeField]
    protected List<Animation> wings;

    [SerializeField]
    private bool isLocked = false;

    [SerializeField]
    private AudioSource doorSound;

    private void Start()
    {
        if (!isLocked)
        {
            this.OpenDoor();
        }
    }

    private void OpenDoor()
    {
        doorSound.Play();

        wings[0]["door_01_wing_left"].speed = 1;
        wings[1]["door_01_wing_right"].speed = 1;
        wings[0].Play();
        wings[1].Play();
    }

    private void CloseDoor()
    {
        doorSound.Play();

        wings[0]["door_01_wing_left"].time = wings[0]["door_01_wing_left"].length;
        wings[1]["door_01_wing_right"].time = wings[1]["door_01_wing_right"].length;
        wings[0]["door_01_wing_left"].speed = -1;
        wings[1]["door_01_wing_right"].speed = -1;
        wings[0].Play();
        wings[1].Play();
    }

    public void Open()
    {
        if (isLocked)
            OpenDoor();
    }

    public void ToggleLock()
    {
        isLocked = !isLocked;

        if (isLocked)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    public void Unlock()
    {
        isLocked = false;
    }
}