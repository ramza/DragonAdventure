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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            if ( hit.transform.tag == "Enemy")
            {
                EnemyStats eStats = hit.transform.GetComponent<EnemyStats>();
                string hp = eStats.curHP.ToString() + "/" + eStats.maxHP.ToString();

                DisplayPopupText(hit.transform.position+Vector3.up*2f, hit.transform.name, hp);
                return;
            }
            else if (hit.transform.tag == "Interactive")
            {
                DisplayPopupText(hit.transform.position, hit.transform.name, "");
                return;
            }
        }

        popupUI.SetActive(false);


    }

    void DisplayPopupText(Vector3 position, string name, string description="")
    {
        
        popupUI.transform.position = cam.WorldToScreenPoint(position);
        popupText.text = name;
        descriptionText.text = description;
        popupUI.SetActive(true);
    }
}
