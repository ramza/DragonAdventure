using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPickup : MonoBehaviour
{
    public bool sword = false;
    public bool armor = true;
    public bool cap= false;
    public bool shoulders= false;

    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (armor)
            {
                other.transform.GetComponentInChildren<EquipmentManager>().ActivateArmor();
            }
            else if (cap)
            {
                other.transform.GetComponentInChildren<EquipmentManager>().ActivateCap();
            }
 
            Destroy(gameObject);
        }
    }
}
