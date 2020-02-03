using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EquipmentManager equipmentManager;
    bool swimming = false;
    Vector3 enterWaterPosition = Vector3.zero;
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
                    hit.transform.GetComponent<DragonController>().ActivateDragon(equipmentManager);
                    gameObject.SetActive(false);
                }
            }
        }

        if (!swimming)
        {
            int layerMask = 1 << 4;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, layerMask))
            {
                print("hit the water");
                GetComponent<PlayerStateMachine>().EnterWater();
                enterWaterPosition = transform.position;
                swimming = true;
            }
        }


        else
        {
            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, layerMask))
            {
                if ( Mathf.Abs(transform.position.x -enterWaterPosition.x) >= 1 && Mathf.Abs(transform.position.z - enterWaterPosition.z) >= 1)
                {
                    print("left the water");
                    GetComponent<PlayerStateMachine>().ExitWater();
                    swimming = false;
                }

     
            }
        }
    }
}
