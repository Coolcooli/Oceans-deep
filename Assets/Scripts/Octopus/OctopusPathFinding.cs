using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class OctopusPathFinding : MonoBehaviour
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; } }
    private Transform model;
    private Animator animator;

    private Transform player;

    [SerializeField] private Transform goal;
    public Transform Goal { get { return goal; } }

    bool walking = false;

    public UnityEvent OnPuzzleFinished;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        model = gameObject.transform.GetChild(0);
        animator = model.GetComponent<Animator>();
        player = Camera.main.transform;
    }

    void Start(){
        moveNext(goal);
    }

    void Update(){
        if (!walking)
        {
            model.LookAt(player);
            model.Rotate(new Vector3(90, 0, 0));
        }

    }

    /// <summary>
    /// function that sets the right animations when the agent arrives at a point
    /// </summary>
    public void Arrive(){
        walking = false;
        animator.SetBool("walking", false);
    }

    /// <summary>
    /// makes the octopus drop the item and stop moving
    /// </summary>
    public void giveUp(){
        OnPuzzleFinished.Invoke();
        Arrive();
        transform.LookAt(new Vector3(transform.position.x, -1, transform.position.z));
        model.GetComponent<ItemDrop>().DropItem();
    }

    /// <summary>
    /// function that changes target destination of nav agent
    /// </summary>
    /// <param name="next">transform point you want the agent to walk to</param>
    public void moveNext(Transform next){
        model.Rotate(new Vector3(-90, 0, 0));
        walking = true;
        animator.SetBool("walking", true);
        agent.destination = next.position;
        goal = next;

    }
}
