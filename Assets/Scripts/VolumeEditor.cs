using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class VolumeEditor : MonoBehaviour
{
    [SerializeField]
    private VolumeProfile volume;

    private Exposure exposure;

    private float originValue = 0;

    private float timeDelay;

    private void Start()
    {
        if (volume.TryGet(out exposure))
        {
            originValue = exposure.compensation.value;
        }
    }

    public IEnumerator Flickering(float amount)
    {
        float times = 0;
        while(times < 5)
        {
            if (volume.TryGet(out exposure))
            {
                exposure.compensation.value = originValue;
                timeDelay = Random.Range(0.05f, 0.3f);
                yield return new WaitForSeconds(timeDelay);
                exposure.compensation.value = amount;
                timeDelay = Random.Range(0.05f, 0.3f);
                yield return new WaitForSeconds(timeDelay);
            }
            times++;
        }
    }

    public void ChangeExposureFlickering(float amount)
    {
        StartCoroutine(Flickering(amount));
    }

    public void ChangeExposure(float amount)
    {
        if (volume.TryGet(out exposure))
        {
            exposure.compensation.value = amount;
        }
    }

    public void Reset()
    {
        if (volume.TryGet(out exposure))
        {
            exposure.compensation.value = originValue;
        }
    }

    private void OnApplicationQuit()
    {
        Reset();
    }
}
