using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public StoryUI storyUI;
    public DialogueNode firstDialogue;
    public Interactive interactive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartDialogue()
    {
        storyUI.gameObject.SetActive(true);
        storyUI.StartDialogue(this);

    }

    public void EndDialogue()
    {
        interactive.EndDialogue();
    }
}
