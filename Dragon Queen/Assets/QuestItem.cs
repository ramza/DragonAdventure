using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    DialogueController dialogueController;
    Interactive interactive;

    public string itemName;
    public string questName;

    // Start is called before the first frame update
    void Start()
    {

        if (GameManager.Instance.playerData.IsQuestStarted(questName))
        {
            if (GameManager.Instance.playerData.hasBook && itemName == "Book")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            //Destroy(gameObject);
        }
        interactive = GetComponent<Interactive>();
        interactive.SetIsQuestItem();
        dialogueController = GetComponent<DialogueController>();
    }

    public void PickUpQuestItem()
    {
        if (GameManager.Instance.playerData.IsQuestStarted (questName)){
            GameManager.Instance.playerData.CompleteQuest(questName);
        }



        switch (itemName)
        {
            case "Mushroom":
                GameManager.Instance.playerData.hasMushroom = true;
                break;
            case "Book":
                GameManager.Instance.playerData.hasBook = true;
                break;
        }

        Destroy(gameObject);
    }

}
