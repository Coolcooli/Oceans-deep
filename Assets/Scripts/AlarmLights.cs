using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLights : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> lights = new List<GameObject>();

    private List<Light> lightObjects = new List<Light>();
    private List<Animation> animations = new List<Animation>();

    private void Awake()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lightObjects.Add(lights[i].GetComponentInChildren<Light>());
            animations.Add(lights[i].GetComponent<Animation>());
        }
    }

    public void AlarmOn()
    {
        for(int i = 0; i < lights.Count; i++)
        {
            lightObjects[i].intensity = 140000;
            animations[i].Play();
        }
    }

    public void AlarmOf()
    {
        for (int i = 0; i < animations.Count; i++)
        {
            lightObjects[i].intensity = 0;
            animations[i].Stop();
        }
    }
}
