using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundSequence : MonoBehaviour
{
    public UnityEvent SequenceDone;

    [SerializeField]
    private List<AudioClip> clips;

    [SerializeField]
    private AudioSource audioSource;

    private bool done = false;
    private int currentClip = 0;

    private void Awake()
    {
        audioSource.clip = clips[currentClip];
        audioSource.Play();
    }

    private void Update()
    {
        if (done)
            return;

        if(!audioSource.isPlaying)
        {
            currentClip++;

            if (currentClip >= clips.Count)
            {
                SequenceDone?.Invoke();
                done = true;
                return;
            }

            audioSource.clip = clips[currentClip];
            audioSource.Play();
        }
    }
}
