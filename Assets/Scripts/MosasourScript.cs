using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosasourScript : MonoBehaviour
{

    SkinnedMeshRenderer[] skins;


    // Start is called before the first frame update
    void Start()
    {
        skins = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    public void EnableMeshWithTimer(int duration)
    {
        ToggleMeshOn(true);

        Invoke("ToggleMeshOff", duration);

    }

    private void ToggleMeshOn(bool value)
    {
        foreach (SkinnedMeshRenderer skin in skins)
        {
            skin.enabled = value;
        }
    }

    private void ToggleMeshOff()
    {
        foreach (SkinnedMeshRenderer skin in skins)
        {
            skin.enabled = false;
        }
    }
}
