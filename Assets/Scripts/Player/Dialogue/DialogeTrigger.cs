using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogeTrigger : MonoBehaviour
{
    public UnityEvent<int> onDialogeTrigger;
    public int index;
    [SerializeField]
    private float invokeDelay = 0f;

    private bool shouldTrigger = true;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            InvokeEventWithDelay();
    }

    public IEnumerator StartDelayedEvent()
    {
        yield return new WaitForSeconds(invokeDelay);

        onDialogeTrigger.Invoke(index);
    }

    public void InvokeEventWithDelay()
    {
        if (!shouldTrigger) return;

        shouldTrigger = false;
        StartCoroutine(StartDelayedEvent());
    }
}
