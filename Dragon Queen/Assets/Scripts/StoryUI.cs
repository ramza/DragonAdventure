using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    public Text storyText;
    private GameObject player;
    private ThirdPersonController thirdPersonController;
    public GameObject[] choiceButtons;
    private bool dialogueOver;
    private DialogueController currentDialogueController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thirdPersonController = player.GetComponent<ThirdPersonController>();
        gameObject.SetActive(false);
    }

    public void StartDialogue(DialogueController dControl)
    {
        thirdPersonController.canMove = false;
        dialogueOver = false;
        currentDialogueController = dControl;
        UpdateStoryText(dControl.firstDialogue);

    }

    public void UpdateStoryText(DialogueNode node)
    {
        ClearDialogueChoices();
        storyText.text = node.mainText;

        if (node.choices.Length == 0)
        {
            choiceButtons[0].SetActive(true);
            choiceButtons[0].GetComponentInChildren<Text>().text = "Ok";
            dialogueOver = true;
            return;
        }
        int i = 0;
        foreach(DialogueNode.DialogueAnswer dAnswer in node.choices)
        {
            choiceButtons[i].SetActive(true);
            choiceButtons[i].GetComponentInChildren<Text>().text = dAnswer.answerText;
            choiceButtons[i].GetComponent<DialogueNode>().choices[0] = dAnswer;
            i++;
        }
        
    }

    private void ClearDialogueChoices()
    {
       foreach (GameObject choice in choiceButtons)
        {
            choice.SetActive(false);
        }
    }

    public void ClickChoice(int choice)
    {
        if (dialogueOver)
        {
            thirdPersonController.canMove = true;
            currentDialogueController.EndDialogue();
            gameObject.SetActive(false);
        }

        UpdateStoryText(choiceButtons[choice].GetComponent<DialogueNode>().choices[0].nextNode);
    }
}
