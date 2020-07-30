using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue conversa;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueSystem>().StartDialogue(conversa);
    }
}
