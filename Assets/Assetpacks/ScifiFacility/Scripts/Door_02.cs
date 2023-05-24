using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Door_02 : BaseDoor
{
    protected override void OpenDoor()
    {
        base.OpenDoor();
        wings[0]["door_02_wing"].speed = 1;
        wings[0].Play();
    }

    protected override void CloseDoor()
    {
        base.CloseDoor();

        wings[0]["door_02_wing"].time = wings[0]["door_02_wing"].length;
        wings[0]["door_02_wing"].speed = -1;
        wings[0].Play();
    }
}
