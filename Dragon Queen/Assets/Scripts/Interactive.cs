using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public DialogueController dialogueController;
 
    private PlayerStateMachine playerStateMachine;

    public void Interact(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
        dialogueController.StartDialogue();
    }

    public void EndDialogue()
    {
        playerStateMachine.thirdPersonController.canMove=true;
    }
}
