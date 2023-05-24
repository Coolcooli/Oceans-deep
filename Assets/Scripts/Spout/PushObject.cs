using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private List<Rigidbody> affectedObjects = new List<Rigidbody>();
    private CharacterController player;
    private const float objStrength = 800f;
    private const float playerStrength = 8f;
    [SerializeField]
    private float maxVelocity = 4f;

    [SerializeField]
    private bool isActive = false;
    [SerializeField]
    private bool isEnabled = true;

    [SerializeField]
    private float duration = 5f;

    [SerializeField]
    private ParticleSystem ps;

    [SerializeField]
    private AudioController audioController;

    private void Awake()
    {
        if (isActive && !isEnabled)
            isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            affectedObjects.Add(other.attachedRigidbody);
        else if (other.GetComponent<CharacterController>())
            player = other.GetComponent<CharacterController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.velocity = Vector3.zero;
            affectedObjects.Remove(other.attachedRigidbody);
        }
        else if (other.GetComponent<CharacterController>())
        {
            player = null;
        }
    }

    private void FixedUpdate()
    {
        if (!isActive) return;

        ApplyPush();
    }

    /// <summary>
    /// Pushes object currently in the affectedObjects list
    /// </summary>
    private void ApplyPush()
    {
        foreach (Rigidbody obj in affectedObjects)
        {
            if (obj.velocity.magnitude < maxVelocity)
                obj.AddForce(objStrength * Time.deltaTime * transform.forward);
        }
        if (player)
            player.Move(playerStrength * Time.deltaTime * transform.forward);
    }

    public void Deactivate()
    {
        isActive = false;
    }

    public void Activate(bool endWithDuration = false)
    {
        if (!isEnabled) return;

        audioController.PlayAudio(duration);
        Invoke(nameof(SetActive), .5f);
        ps.Play();
        if (endWithDuration)
            Invoke(nameof(Deactivate), duration);
    }

    private void SetActive()
    {
        isActive = true;
    }

    public void Enable()
    {
        isEnabled = true;
    }
}
