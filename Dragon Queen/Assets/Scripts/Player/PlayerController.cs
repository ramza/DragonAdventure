using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var actionBtn = Input.GetKeyDown(KeyCode.R);

        RaycastHit hit;

        if ( Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            if(hit.transform.tag == "Dragon")
            {
                if (actionBtn)
                {
                    hit.transform.GetComponent<DragonController>().ActivateDragon();
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
