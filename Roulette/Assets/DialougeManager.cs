using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge (Dialouge dialouge)
    {

        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void displayNestSentence ()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue;
            return;
        }
        string sentence = sentences.Dequeue();
    }

    void EndDialouge()
    {
        Debug.Log("END");
    }

}
