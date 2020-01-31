using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject escapeMenu;
    bool escapeMenuOn;
    public ThirdPersonController thirdPersonController;

    // Start is called before the first frame update
    void Start()
    {
        escapeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscapeMenu();
        }    
    }

    public void ToggleEscapeMenu()
    {
        escapeMenuOn = !escapeMenuOn;
        if (escapeMenuOn)
        {
            escapeMenu.SetActive(true);
            thirdPersonController.canMove = false;
        }
        else
        {
            escapeMenu.SetActive(false);
            thirdPersonController.canMove = true;
        }
    }
}
