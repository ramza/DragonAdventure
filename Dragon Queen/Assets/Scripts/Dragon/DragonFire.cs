using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire : MonoBehaviour
{

    public bool activated;
    GameObject curretTarget;
    BoxCollider hitBox;
    private float timer;
    private float hurtDelay = 0.1f;

    private void Start()
    {
        hitBox = GetComponent<BoxCollider>();
        hitBox.enabled = false;
    }

    private void Update()
    {
        if (activated && curretTarget)
        {
            timer += Time.deltaTime;
            if (timer > hurtDelay)
            {
                print("buring the gobling");
                curretTarget.transform.GetComponent<EnemyHealthManager>().Hurt(1f);
            }
        }
  
    }
    

    public void EnableFire()
    {
        hitBox.enabled = true;
    }

    public void DisableFire()
    {
        hitBox.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("draong fire collision");
        if (other.transform.GetComponent<EnemyHealthManager>())
        {
            curretTarget = other.gameObject;

        }
        else if (other.transform.GetComponent<DragonGate>())
        {
            other.GetComponent<DragonGate>().Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject == curretTarget)
        {
            curretTarget = null;

        }
    }
}
