using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elizadore : MonoBehaviour
{
    public GameObject mushroomWizard;
    public GameObject bookWizard;

    // Start is called before the first frame update
    void Start()
    {
        mushroomWizard.SetActive(false);
        bookWizard.SetActive(false);


        if (GameManager.Instance.playerData.questCompleteMushroom)
        {
            bookWizard.SetActive(true);
        }
        else
        {
            mushroomWizard.SetActive(true);
        }

    }

    public void FinishQuest(string questName)
    {
        switch (questName)
        {
            case "Find a Mushroom.":
                GameManager.Instance.playerData.questCompleteMushroom = true;
                break;
            case "Find a Book.":
                GameManager.Instance.playerData.questCompleteBook = true;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
