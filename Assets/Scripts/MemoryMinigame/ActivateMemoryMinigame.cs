using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMemoryMinigame : MonoBehaviour
{
    [SerializeField]
    private Canvas minigameCanvas;
    [SerializeField]
    private MemoryMinigame memory;
    private CanvasGroup cg;
    // Start is called before the first frame update
    void Start()
    {
        cg = minigameCanvas.GetComponent<CanvasGroup>();
        cg.alpha = 0;
    }

    public void ActivateMinigame()
    {
        cg.alpha = 1;
        memory.StartMinigame();
    }
}
