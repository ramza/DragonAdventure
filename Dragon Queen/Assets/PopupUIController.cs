using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupUIController : MonoBehaviour
{
    public GameObject popupUI;
    public Text popupText;
    public Text descriptionText;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if(!cam)
            cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        popupUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {

            if ( hit.transform.tag == "Interactive")
            {
                DisplayPopupText(hit.transform.position, hit.transform.name, "");
                return;
            }
        }

        popupUI.SetActive(false);
        Debug.Log("turn off popup text");

    }

    void DisplayPopupText(Vector3 position, string name, string description="")
    {
        
        popupUI.transform.position = cam.WorldToScreenPoint(position);
        popupText.text = name;
        descriptionText.text = description;
        popupUI.SetActive(true);
    }
}
