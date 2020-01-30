using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{
    public Camera camera;
    PlayerStateMachine psm;

    private void Start()
    {
        psm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();    
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.


            if (hit.transform.GetComponent<Interactive>() && Input.GetMouseButtonDown(0))
            {
                Interactive interactive = hit.transform.GetComponent<Interactive>();
                interactive.Interact(psm);
            }
        }
    }
}