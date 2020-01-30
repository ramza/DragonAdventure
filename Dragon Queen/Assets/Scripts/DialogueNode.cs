using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour
{
    [TextArea(3, 5)]
    public string mainText;

    public DialogueAnswer[] choices;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }


    [System.Serializable]
    public class DialogueAnswer
    {
        public string answerText;
        public DialogueNode nextNode;
    }
}
