using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterController : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isDraining = false;

    [SerializeField]
    private float movementSpeed = .4f;

    [SerializeField]
    private float raiseAmount = .15f;

    public UnityEvent onDrained;

    [SerializeField]
    private float drainAmount = 1f;

    private void FixedUpdate()
    {
        if (!isMoving) return;

        if (Mathf.Abs(targetPosition.y - transform.position.y) < 0.1f)
        {
            isMoving = false;
            if (isDraining)
            {
                Destroy(gameObject);
                onDrained?.Invoke();
            }
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
    }

    public void StartRaise()
    {
        targetPosition = transform.position + raiseAmount * transform.up;
        isMoving = true;
    }

    public void Drain()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y - drainAmount, transform.position.z);
        isMoving = true;
        isDraining = true;
    }
}
