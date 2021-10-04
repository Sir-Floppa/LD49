using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameplayManager GM;

    public Queue<string> sentences;

    public Text dialogueText;

    public bool inDialogue = false;

    public Dialogue ActiveDialogue;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation");
        ActiveDialogue = dialogue;
        
        if (!inDialogue)
        {
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            inDialogue = true;
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        dialogueText.text = "";

        StartCoroutine(TypeText(sentence));


        // dialogueText.text = sentence;
    }

    IEnumerator TypeText(string sentence)
    {
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of the conversation");
        inDialogue = false;

        ActiveDialogue.onEndToDecide.StartDecition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
