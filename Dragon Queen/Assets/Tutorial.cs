using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    Interactive interactive;
    bool activated = false;
    SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        interactive = GetComponent<Interactive>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(!activated && other.transform.tag == "Player")
        {
            print("trigger tutorial");
            activated = true;
            interactive.Interact(other.GetComponent<PlayerStateMachine>());
            sphereCollider.enabled = false;
        }
    }
}
