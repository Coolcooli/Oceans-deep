using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SettingsScript : MonoBehaviour
{
    //Script variables
    [SerializeField]
    private Scene currentScene;
    private GameObject previousCanvas;

    //sense variables
    [SerializeField]
    private PlayerLookInput playerInput;
    public TMP_Text playerSense;
    public GameObject senseParentGO;
    public float newPlayerSense;
    public float newVolume;

    //volume variables
    public TMP_Text volumeText;

    //resolution variables
    public int currentResolutionIndex;
    public FullScreenMode fullScreenMode = FullScreenMode.FullScreenWindow;
    public GameObject resolutionDropdownGO;
    private TMP_Dropdown resolutionDropdown;
    public Camera currentCamera;
    public Resolution maxResolution;
    private List<Resolution> resolutionOptions = new List<Resolution>();


    private void Start()
    {
        resolutionDropdown = resolutionDropdownGO.GetComponent<TMP_Dropdown>();
        resolutionDropdown.ClearOptions();
        PopulateResolutionDropdown();

        if (playerSense != null) playerSense.text = playerInput.mouseSensitivity.ToString();
        float volume = AudioListener.volume * 100;
        volumeText.text = volume.ToString() + "%";
    }

    public void openSettings(GameObject canvas)
    {
        if (canvas.name == "Menu")
        {
            senseParentGO.SetActive(false);
            playerSense = null;
        }
        previousCanvas = canvas;
        gameObject.SetActive(true);
        previousCanvas.SetActive(false);
    }

    public void SetResolution()
    {
        Resolution resolution = resolutionOptions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, true);
        float aspectRatio = (float)resolution.width / resolution.height;
        currentCamera.aspect = aspectRatio;
        Debug.Log("new res: " + resolution + " aspectRatio: " + aspectRatio);
    }


    public void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentRes = 0;
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            Resolution resolution = Screen.resolutions[i];
            if (resolution.refreshRateRatio.ToString() == Screen.currentResolution.refreshRateRatio.ToString())
            {
                string option = resolution.width + "x" + resolution.height;
                options.Add(option);
                resolutionOptions.Add(Screen.resolutions[i]);
            }
        }
        Resolution currentResolution = Screen.currentResolution;
        currentRes = resolutionOptions.FindIndex(x => x.Equals(currentResolution));

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();
    }

    public void changeSense(float sense)
    {
        playerSense.text = sense.ToString();
        newPlayerSense = sense;
    }

    public void changeVolume(float volume)
    {
        newVolume = volume / 100;
        volumeText.text = volume.ToString() + "%";
    }

    public void exitSettings()
    {
        if (previousCanvas.name == "Menu")
        {
            senseParentGO.SetActive(true);
        }
        previousCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void applySettings()
    {
        if (playerSense != null) playerInput.mouseSensitivity = newPlayerSense;
        AudioListener.volume = newVolume;
        SetResolution();
    }
}

