using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> frases;


    /* 
        Para comecar o texto, deve-se implementar um trigger no NPC/Objeto interagido. 
        Este, deve passar as informacoes de qual texto a ser passado (Dialogue Trigger).
        Implementar, tambem um jeito de sumir a UI (provavelmente, escala = 000)

         
         */

    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // animacao de abrir o balao

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
        // animacao pra fechar o balao
    }
}
