using UnityEngine.InputSystem;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField]private GameObject pauseUI;
    [SerializeField] private GameObject Player;


    /// <summary>
    /// function that pauses the game
    /// </summary>
    public void Pause(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;

        GameObject[] UI = GameObject.FindGameObjectsWithTag("UI");

        foreach(GameObject UIobj in UI){

            UIobj.SetActive(false);
        }

        pauseUI.SetActive(true);


        PlayerInput input = Player.GetComponent<PlayerInput>();

        input.actions.FindActionMap("Player").Disable();
        input.actions.FindActionMap("UI").Enable();

    }
}
