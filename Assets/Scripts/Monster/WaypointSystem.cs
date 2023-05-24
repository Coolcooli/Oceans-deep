using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 30f;
    public float MovementSpeed { set { movementSpeed = value; } }

    [SerializeField]
    private Transform[] waypoints;
    private int iWaypoint = 0;

    private Transform currentTarget;
    public Transform CurrentTarget { get { return currentTarget; } }
    private float maxRotationSpeed = 1;

    [SerializeField]
    private bool loop = false;
    [SerializeField]
    private bool shouldMove = true;
    public bool ShouldMove { get { return shouldMove; } set { shouldMove = value; } }

    private void Start()
    {
        if (waypoints.Length > 0)
            SetWaypoint(waypoints[iWaypoint]);
    }

    private void FixedUpdate()
    {
        if (currentTarget == null) return;

        SetNextWaypoint();
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (!shouldMove) return;

        Vector3 direction = (currentTarget.transform.position - transform.position).normalized;

        //Quaternion targetRotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationSpeed);

        // Rotate the object to the target
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * maxRotationSpeed);

        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    public void SetWaypoint(Transform target)
    {
        if (target == null) return;

        shouldMove = true;
        currentTarget = target;
    }

    public void SetNextWaypoint()
    {
        if (Vector3.Distance(transform.position, currentTarget.transform.position) < 1)
        {
            iWaypoint++;
            if (iWaypoint < waypoints.Length)
            {
                currentTarget = waypoints[iWaypoint];
            }
            else
            {
                if(loop)
                {
                    iWaypoint = 0;
                    currentTarget = waypoints[iWaypoint];
                    return;
                }
                shouldMove = false;
            }
        }
    }
}