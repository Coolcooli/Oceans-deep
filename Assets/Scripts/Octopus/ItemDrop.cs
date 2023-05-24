using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject item;//the item that the octopus can drop
    [SerializeField] private Transform holdPos;

    // Start is called before the first frame update

    /// <summary>
    /// makes a copy of the item for the octopus to hold
    /// </summary>
    private void Start(){
        if(item == null){
            Debug.LogError("No item given to octopus");
            return;
        }
        item.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z - 0.25f), transform.rotation);
        item.transform.parent = transform;
        item.transform.Rotate(new Vector3(0, 90, 0));
    }

    /// <summary>
    /// makes the octopus stop moving
    /// </summary>
    public void DropItem(){
        if(item == null)
            return;
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<BoxCollider>().enabled = true;
        item.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
    }
}
