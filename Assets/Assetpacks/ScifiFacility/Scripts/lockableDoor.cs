using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class lockableDoor : Door_02
{

    void Start(){
        if(!IsLocked)
            OpenDoor();
    }

public override void ToggleLock()
    {
        if(IsLocked)
            UnlockDoor();
        else
            lockDoor();
    }

    public override void lockDoor()
    {
        base.lockDoor();
        CloseDoor();
    }

    public override void UnlockDoor()
    {
        base.UnlockDoor();
        OpenDoor();
    }
}