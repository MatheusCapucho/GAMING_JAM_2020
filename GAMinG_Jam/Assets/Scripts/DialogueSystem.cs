using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> frases;

    public Animator anim;

    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("Pop", true);

        frases.Clear();

        nameText.text = dialogue.unitName;

        foreach (string frase in dialogue.frases)
        {
            frases.Enqueue(frase);
        }

        NextFrase();

    }
    public void NextFrase()
    {
        if (frases.Count == 0)
        {
            EndConversation();
            return;
        }

        dialogueText.text = frases.Dequeue();
    }
    public void EndConversation()
    {
        anim.SetBool("Pop", false);
    }
}
