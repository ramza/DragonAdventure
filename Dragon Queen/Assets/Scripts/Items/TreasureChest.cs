using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public DialogueController dialogueController;
    public GameObject openChest;
    public GameObject closedChest;
    private PlayerStateMachine playerStateMachine;
    public Transform playerTransform;
    public GameObject[] treasures;
    bool opened = false;

    private void Start()
    {

        openChest.SetActive(false);
    }
    public void Open(PlayerStateMachine playerStateMachine)
    {
        if (opened || !(Mathf.Abs(playerTransform.position.x - transform.position.x) < 5f && Mathf.Abs(playerTransform.transform.position.z-transform.position.z) < 5f)) 
        {
            return;
        }
        this.playerStateMachine = playerStateMachine;
        if(dialogueController.firstDialogue != null)
        {
            dialogueController.StartDialogue();
            GetComponent<Interactive>().SetPSM(playerStateMachine);
        }


        openChest.SetActive(true);
        closedChest.SetActive(false);
        opened = true;

        for (int i = 0; i < treasures.Length; i++)
        {
            print(i);
            GameObject go = Instantiate(treasures[i], transform);
            Vector3 pos = new Vector3(-1+i, 0, 0);
            go.transform.position = transform.position + pos + transform.forward;
        }
    }

    public void EndDialogue()
    {
        playerStateMachine.thirdPersonController.canMove = true;
    }
}
