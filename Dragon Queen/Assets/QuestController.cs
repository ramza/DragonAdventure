using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public string questName;
    public DialogueNode startDialogue;
    public DialogueNode hintDialogue;
    public DialogueNode endDialogue;

    public DialogueController dialogueController;
    private Interactive interactive;
    // Start is called before the first frame update
    void Start()
    {
        interactive = GetComponent<Interactive>();
        interactive.SetIsQuest();
        UpdateDialogue();
    }

    public void StartQuest()
    {
        UpdateDialogue();
        // start the quest
        GameManager.Instance.playerData.AddQuest(questName);
        
        

    }

    public void UpdateDialogue()
    {
        // started, but not finished, the quest
        if (GameManager.Instance.playerData.IsQuestStarted(questName))
        {
            // we've completed the quest
            if (GameManager.Instance.playerData.IsQuestComplete(questName))
            {
                print("quest comaplete");
                dialogueController.firstDialogue = endDialogue;
                return;
            }

            dialogueController.firstDialogue = hintDialogue;
            return;
        }

        dialogueController.firstDialogue = startDialogue;
    }
}
