using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGate : MonoBehaviour
{

    bool triggered = false;
    float timer;
    float delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            transform.position += Vector3.down * 5f * Time.deltaTime;
            timer += Time.deltaTime;
            if(timer > delay)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Open()
    {
        if (!triggered)
        {
            triggered = true;
        }
    }
}
