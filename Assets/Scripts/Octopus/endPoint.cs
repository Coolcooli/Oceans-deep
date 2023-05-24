using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class endPoint : MonoBehaviour{


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lizard"))
            other.GetComponent<OctopusPathFinding>().giveUp();
    }

}