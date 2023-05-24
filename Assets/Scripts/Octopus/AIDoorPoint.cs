using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDoorPoint : AIPoint
{
    [SerializeField] BaseDoor northDoor;
    [SerializeField] BaseDoor eastDoor;
    [SerializeField] BaseDoor southDoor;
    [SerializeField] BaseDoor westDoor;

    private Dictionary<Approachdir, BaseDoor> Doors = new Dictionary<Approachdir, BaseDoor>();



    protected override void Start()
    {
        Doors.Add(Approachdir.north, southDoor);
        Doors.Add(Approachdir.east, westDoor);
        Doors.Add(Approachdir.south, northDoor);
        Doors.Add(Approachdir.west, eastDoor);
        base.Start();
    }

    /// <summary>
    /// finds the right direction the agent has to go considering doors
    /// </summary>
    /// <param name="direction">the direciton that the agent is supposed to go</param>
    protected override void SendNext(Approachdir direction)
    {
        Approachdir newDirection = CheckDoor(direction);

        //if the agent can't go further and has to turn around, it loses
        if(newDirection == getOpposit(direction)){
            Debug.Log("give up");
            lizard.giveUp();
            return;
        }
        base.SendNext(newDirection);
    }

    /// <summary>
    /// checks if the agent can go a specific direction or gets redirected to another direction
    /// </summary>
    /// <param name="direction">the direction the agent wants to go</param>
    /// <returns>the direction the agent should go</returns>
    private Approachdir CheckDoor(Approachdir direction, int depth = 0){
        Approachdir checkdirection = getCheckdirection(direction, depth);

        if(Doors[checkdirection] == null || !Doors[checkdirection].IsLocked)
             return checkdirection;
        if (depth >= 4)
            return getOpposit(direction);

        return CheckDoor(direction, ++depth);
    }

    /// <summary>
    /// gets the opposit of a direction
    /// </summary>
    /// <param name="direction">the direction you need an opposit off</param>
    /// <returns> the opposit</returns>
    private Approachdir getOpposit(Approachdir direction){
        switch (direction){
            case Approachdir.north:
                return Approachdir.south;
            case Approachdir.east:
                return Approachdir.west;
            case Approachdir.south:
                return Approachdir.north;
            default:
                return Approachdir.east;
        }
    }

    /// <summary>
    /// function that converts approchdirection to checkdirection
    /// </summary>
    /// <param name="direction">approach direction</param>
    /// <param name="depth">the depth of the door check recursion</param>
    /// <returns>direction that needs to be checked</returns>
    private Approachdir getCheckdirection(Approachdir direction, int depth){
        switch (direction){
            case Approachdir.north:
                if(depth == 0)
                    return direction;
                else if (depth == 1)
                    return Approachdir.east;
                else if(depth == 2)
                    return Approachdir.west;
                else
                    return Approachdir.south;

            case Approachdir.east:
                if(depth == 0)
                    return direction;
                else if (depth == 1)
                    return Approachdir.south;
                else if(depth == 2)
                    return Approachdir.north;
                else
                    return Approachdir.west;

            case Approachdir.south:
                if(depth == 0)
                    return direction;
                else if (depth == 1)
                    return Approachdir.west;
                else if(depth == 2)
                    return Approachdir.east;
                else
                    return Approachdir.north;

            case Approachdir.west:
                if(depth == 0)
                    return direction;
                else if (depth == 1)
                    return Approachdir.north;
                else if(depth == 2)
                    return Approachdir.south;
                else
                    return Approachdir.east;
        }
        Debug.LogError(direction +"is not a valid direction");
        return direction;
    }
}