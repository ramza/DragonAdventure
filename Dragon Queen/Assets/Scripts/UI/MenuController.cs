using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject escapeMenu;
    public GameObject mapMenu;
    bool mapMenuOn;
    bool escapeMenuOn;
    public ThirdPersonController thirdPersonController;

    // Start is called before the first frame update
    void Start()
    {
        escapeMenu.SetActive(false);
        mapMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(mapMenuOn)
            {
                ToggleMapMenu();
            }
            ToggleEscapeMenu();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (escapeMenuOn)
            {
                return;
            }
            ToggleMapMenu();
        }

    }

    public void ToggleMapMenu()
    {
        mapMenuOn = !mapMenuOn;
        if (mapMenuOn)
        {
            mapMenu.SetActive(true);
            thirdPersonController.canMove = false;
        }
        else
        {
            mapMenu.SetActive(false);
            thirdPersonController.canMove = true;
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
