using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    public Image mushroomIcon;
    public Image bookIcon;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (GameManager.Instance.playerData.hasMushroom)
        {
            mushroomIcon.enabled = true;
        }
        else
        {
            mushroomIcon.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
