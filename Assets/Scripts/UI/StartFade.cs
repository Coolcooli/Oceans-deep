using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFade : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ManualFadeIn(float animationSpeed)
    {
        animator.Play("FadeIn");
        animator.speed = animationSpeed;
    }

    public void ManualFadeOut(float animationSpeed)
    {
        animator.Play("FadeOut");
        animator.speed = animationSpeed;
    }
}