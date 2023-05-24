using UnityEngine.InputSystem;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField]private GameObject[] UI;//list of UI that needs to get activated again
    [SerializeField] private GameObject Player;


    /// <summary>
    /// function that closes the pause screen
    /// </summary>
    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;

        foreach(GameObject UIobj in UI){
            if(UIobj == transform.parent.gameObject) continue;

            UIobj.SetActive(true);
        }

        transform.parent.gameObject.SetActive(false);

         PlayerInput input = Player.GetComponent<PlayerInput>();
        
         input.actions.FindActionMap("Player").Enable();
         input.actions.FindActionMap("UI").Disable();
    }
}
