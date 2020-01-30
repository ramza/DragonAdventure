using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    public Text storyText;

    public GameObject[] choiceButtons;
    private bool dialogueOver;
    private DialogueController currentDialogueController;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartDialogue(DialogueController dControl)
    {
        dialogueOver = false;
        currentDialogueController = dControl;
        UpdateStoryText(dControl.firstDialogue);
    }

    public void UpdateStoryText(DialogueNode node)
    {
        ClearDialogueChoices();
        storyText.text = node.mainText;

        if (node.choiceText.Length == 0)
        {
            choiceButtons[0].SetActive(true);
            choiceButtons[0].GetComponentInChildren<Text>().text = "Ok";
            dialogueOver = true;
            return;
        }

        for (int i = 0; i < node.choiceText.Length; i++)
        {
            choiceButtons[i].SetActive(true);
            choiceButtons[i].GetComponentInChildren<Text>().text = node.choiceText[i];
            choiceButtons[i].GetComponent<DialogueNode>().Copy(node.choices[i].choices, node.choices[i].choiceText, node.choices[i].mainText);
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
            currentDialogueController.EndDialogue();
            gameObject.SetActive(false);
        }

        UpdateStoryText(choiceButtons[choice].GetComponent<DialogueNode>());
    }
}
