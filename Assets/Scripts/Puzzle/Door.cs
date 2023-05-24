using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private bool opened = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("open", opened);
    }

    public void ToggleDoor()
    {
        opened = !opened;

        animator.SetBool("open", opened);
    }

    public void OpenDoor()
    {
        opened = true;

        animator.SetBool("open", opened);
    }
}
