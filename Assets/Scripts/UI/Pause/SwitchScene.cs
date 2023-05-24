using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    private float delay = 0;

    public void SwitchTo(string name)
    {
        StartCoroutine(Switch(name));
    }

    private IEnumerator Switch(string name)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
