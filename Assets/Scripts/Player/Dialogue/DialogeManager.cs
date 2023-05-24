using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogeManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text DialogeText; //Textfield for the dialoge
    private string currentName; //name for dialoge
    [SerializeField]
    private TextAsset jsonFile; //JSON file containing all dialoges
    private List<Dialoge> dialoges = new List<Dialoge>(); //list of all dialoges

    [SerializeField]
    private float readSpeed = 0.05f;//time between displaying each letter in a sentence
    [SerializeField]
    private float deleteTime = 4f; //time to wait before removing dialoge text
    private Queue<string> sentences; //Queue of all sentences


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        ImportDialoges();
    }

    public void ImportDialoges()
    {
        Dialoges dialog = JsonUtility.FromJson<Dialoges>(jsonFile.text);

        foreach (Dialoge dialoge in dialog.dialoges)
        {
            dialoges.Add(dialoge);
        }
    }

    /// <summary>
    /// Function to start a new Dialoge
    /// </summary>
    /// <param name="dialoge"></param>
    public void StartDialoge(int index)
    {
        Dialoge dialoge = dialoges[index];
        sentences.Clear();

        foreach (string sentence in dialoge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        currentName = dialoge.name;
        DisplayNextSentence();
    }

    /// <summary>
    /// Function to display the next sentence in the dialoge sequence
    /// </summary>
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(RemoveDialogue(sentence.ToCharArray().Length));
    }

    /// <summary>
    /// Function to end the Dialoge
    /// </summary>
    public void EndDialogue()
    {
        //END DIALOGUE
    }

    /// <summary>
    /// Coroutine to display all letters one by one
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence(string sentence)
    {
        DialogeText.text = currentName + ": ";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogeText.text += letter;
            yield return new WaitForSeconds(readSpeed);
        }
    }

    /// <summary>
    /// Coroutine used to remove the dialoge
    /// </summary>
    /// <returns></returns>
    IEnumerator RemoveDialogue(int senctenceLength)
    {
        float sentenceTime = senctenceLength * readSpeed;
        yield return new WaitForSeconds(sentenceTime + deleteTime);
        DialogeText.text = "";
        if (sentences.Count != 0)
        {
            DisplayNextSentence();
        }
    }

}
