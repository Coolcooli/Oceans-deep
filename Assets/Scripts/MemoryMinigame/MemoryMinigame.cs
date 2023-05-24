using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryMinigame : MonoBehaviour
{
    [SerializeField]
    private Image[] buttons;
    [SerializeField]
    private CanvasGroup cg;
    [SerializeField]
    private BoxCollider doorCollider;

    private List<int> correctButtons = new List<int>();
    private List<int> pressedButtons = new List<int>();

    private bool waiting = true;
    private bool finished = false;
    private bool lost = false;
    private bool activated = false;

    [SerializeField]
    private PlayerLookInput playerLook;

    /// <summary>
    /// Get number of clicked button
    /// </summary>
    /// <param name="number"></param>
    public void GiveNumber(int number)
    {
        if (!waiting)
        {
            //buttons[number].color = Color.red;
            pressedButtons.Add(number);
        }
    }

    /// <summary>
    /// Method to start the minigame
    /// </summary>
    public void StartMinigame()
    {
        if (activated) return;

        ResetGame();
        for (int i = 0; i < 4; i++)
        {
            correctButtons.Add(Random.Range(0, 15));
        }

        StartCoroutine(ShowCorrectButtons());
        playerLook.AllowLookInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (pressedButtons.Count == 4 && !finished)
        {
            int i = 0;
            foreach (int btn in pressedButtons)
            {

                int j = 0;
                foreach (int correctbtn in correctButtons)
                {
                    if (i == j)
                    {
                        if (correctbtn != btn)
                        {
                            lost = true;
                        }
                    }
                    j++;
                }
                i++;
            }
            waiting = true;


            finished = true;
        }

        if (lost)
        {
            StartCoroutine(GameLostButtons());
        }
        else if (finished)
        {
            StartCoroutine(GameWonButtons());
        }
    }

    /// <summary>
    /// Coroutine to show the correct buttons at the start of the minigame
    /// </summary>
    /// <returns>Yield return</returns>
    IEnumerator ShowCorrectButtons()
    {
        foreach (int btn in correctButtons)
        {
            buttons[btn].color = Color.green;
            yield return new WaitForSeconds(1);
            buttons[btn].color = Color.white;
        }
        waiting = false;
    }

    /// <summary>
    /// Coroutine to show the buttons and leave the minigame when you won
    /// </summary>
    /// <returns>Yield return</returns>
    IEnumerator GameWonButtons()
    {
        foreach (int btn in correctButtons)
        {
            buttons[btn].color = Color.green;
        }

        yield return new WaitForSeconds(5);

        GameWon();
    }

    /// <summary>
    /// Exit the won minigame
    /// </summary>
    public void GameWon()
    {
        //TODO: Exit minigame
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cg.alpha = 0;
        playerLook.AllowLookInput = true;
        doorCollider.enabled = false;
        EndGame();
    }

    /// <summary>
    /// Coroutine to show the incorrect pressed buttons and exit the minigame
    /// </summary>
    /// <returns></returns>
    IEnumerator GameLostButtons()
    {
        foreach (int btn in pressedButtons)
        {
            buttons[btn].color = Color.red;
        }
        yield return new WaitForSeconds(3);
        GameLost();
    }

    /// <summary>
    /// Exit the lost minigame
    /// </summary>
    public void GameLost()
    {
        //TODO: Exit minigame
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cg.alpha = 0;
        playerLook.AllowLookInput = true;
        activated = false;
        EndGame();
    }

    private void EndGame()
    {
        finished = false;
        lost = false;
        waiting = true;
        pressedButtons.Clear();
        correctButtons.Clear();
    }

    public void ResetGame()
    {
        activated = true;
        foreach (Image btn in buttons)
        {
            btn.color = Color.white;
        }
    }
}
