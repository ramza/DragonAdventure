using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public DialogueController dialogueController;
 
    private PlayerStateMachine playerStateMachine;

    bool enableDragonFollow;
    GameObject dragon;

    bool isQuest;
    bool isQuestItem;

    public void SetIsQuestItem()
    {
        isQuestItem = true;
    }

    public void SetIsQuest()
    {
        isQuest = true;
    }

    public void SetEnableDragonFollow()
    {
        enableDragonFollow = true;
    }

    public void Interact(PlayerStateMachine playerStateMachine)
    {

        this.playerStateMachine = playerStateMachine;
        playerStateMachine.SetIldeState();
 
        if (isQuest)
        {
            GetComponent<QuestController>().StartQuest();
        }
        if (isQuestItem)
        {
            GetComponent<QuestItem>().PickUpQuestItem();
        }

        dialogueController.StartDialogue();
    }

    public void SetPSM(PlayerStateMachine psm)
    {
        this.playerStateMachine = psm;
    }

    public void EndDialogue()
    {
        playerStateMachine.thirdPersonController.canMove=true;
        if (enableDragonFollow)
        {
            EnableDragonFollow();
        }

        if (isQuest)
        {
            GetComponent<QuestController>().UpdateDialogue();
        }

    }

    public void EnableDragonFollow()
    {
        GameObject.FindGameObjectWithTag("Dragon").GetComponent<BasicFollow>().enabled = true;
    }

}
