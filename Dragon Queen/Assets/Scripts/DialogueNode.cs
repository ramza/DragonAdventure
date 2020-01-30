using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour
{
    public string mainText;

    public DialogueNode[] choices;
    public string[] choiceText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Copy(DialogueNode[] choices, string[] choiceText, string mainText)
    {
        this.mainText = mainText;
        this.choiceText = choiceText;
        this.choices = choices;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
