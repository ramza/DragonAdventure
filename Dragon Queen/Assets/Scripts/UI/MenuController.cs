using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject escapeMenu;
    public GameObject mapMenu;
    public GameObject itemMenu;
    bool mapMenuOn;
    bool escapeMenuOn;
    bool itemMenuOn;
    public ThirdPersonController thirdPersonController;

    // Start is called before the first frame update
    void Start()
    {
        escapeMenu.SetActive(false);
        mapMenu.SetActive(false);
        itemMenu.SetActive(false);
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
            if (itemMenuOn)
            {
                ToggleItemMenu();
            }
                ToggleEscapeMenu();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (escapeMenuOn || itemMenuOn)
            {
                return;
            }
            ToggleMapMenu();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (!escapeMenuOn && !mapMenuOn)
            {
                ToggleItemMenu();
            }
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

    public void ToggleItemMenu()
    {
        itemMenuOn = !itemMenuOn;
        if (itemMenuOn)
        {
            Time.timeScale = 0;
            itemMenu.SetActive(true);
            thirdPersonController.canMove = false;
        }
        else
        {
            Time.timeScale = 1;
            itemMenu.SetActive(false);
            thirdPersonController.canMove = true;
        }
    }

    public void ToggleEscapeMenu()
    {
        escapeMenuOn = !escapeMenuOn;
        if (escapeMenuOn)
        {
            Time.timeScale = 0;
            escapeMenu.SetActive(true);
            thirdPersonController.canMove = false;
        }
        else
        {
            Time.timeScale = 1;
            escapeMenu.SetActive(false);
            thirdPersonController.canMove = true;
        }
    }
}
