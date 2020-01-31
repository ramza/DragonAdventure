using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeUI : MonoBehaviour
{
    public MenuController menuControl;


    public void ClickContinueButton()
    {
        menuControl.ToggleEscapeMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
