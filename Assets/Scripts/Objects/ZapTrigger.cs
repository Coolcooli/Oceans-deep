using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    private void OnParticleCollision(GameObject other)
    {
        sound.Play();
    }
}
