using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickupable : Interactable
{
    private Rigidbody rb;
    private Collider col;

    [SerializeField]
    private Vector3 holdRotation = default;
    [SerializeField]
    private Vector3 holdOffset = new Vector3(0.5f, 0.4f, 0.6f);
    [SerializeField]
    private Vector3 holdScale = default;
    private Vector3 scale;

    private bool isLocked = false;
    public bool IsLocked { set { isLocked = value; } get { return isLocked; } }

    void Awake()
    {
        //stores the real scale
        scale = transform.localScale;

        holdScale = (holdScale == default) ? scale : holdScale;
        holdRotation = (holdRotation == default) ? transform.eulerAngles : holdRotation;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    /// <summary>
    /// attaches the object to the player that picks it up
    /// </summary>
    /// <param name="player">the player that picks it up</param>
    public virtual void Pickup(GameObject player)
    {
        if (IsLocked) return;
        //sets the location to the hand and the parent to the player
        transform.parent = player.transform;
        transform.localPosition = holdOffset;
        transform.localScale = holdScale;
        transform.localEulerAngles = holdRotation;

        //disables gravity and collision
        rb.isKinematic = true;
        col.enabled = false;
    }
    /// <summary>
    /// transfers the object from the player back to the environment
    /// </summary>
    /// <param name="player">player that drops the item</param>
    public void Drop()
    {
        transform.parent = null;
        transform.localScale = scale;

        //enables gravity and collision
        rb.isKinematic = false;
        col.enabled = true;

        rb.AddForce(((transform.forward*.5f) + transform.up) * 150);
    }

    public void DoDestroy()
    {
        Destroy(this.gameObject);
    }
}
