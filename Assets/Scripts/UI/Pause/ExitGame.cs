using UnityEngine;

public class ExitGame : MonoBehaviour
{
    /// <summary>
    /// stops the game from running, can later be edited for quiting game logic
    /// </summary>
   public void Exit(){
        Application.Quit();
    }
}
