using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{
    public Camera camera;
    PlayerStateMachine psm;
    float maxDistance = 5f;

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

            if (Input.GetMouseButtonDown(0) && hit.transform.GetComponent<TreasureChest>())
            {
                if(Mathf.Abs(hit.transform.position.x-transform.position.x) < maxDistance && Mathf.Abs(hit.transform.position.z-transform.position.z) < maxDistance)
                {
                    TreasureChest chest = hit.transform.GetComponent<TreasureChest>();
                    chest.Open(psm);
                }
 
            }
            else if (Input.GetMouseButtonDown(0) && hit.transform.GetComponent<Interactive>())
            {
                if (!psm.thirdPersonController.canMove)
                {
                    return;
                }
                if (Mathf.Abs(hit.transform.position.x - transform.position.x) < maxDistance && Mathf.Abs(hit.transform.position.z - transform.position.z) < maxDistance)
                {
                    Interactive interactive = hit.transform.GetComponent<Interactive>();
                    interactive.Interact(psm);
                }
            }
            else if (Input.GetMouseButtonDown(0) && hit.transform.GetComponent<Portal>())
            {
                if (Mathf.Abs(hit.transform.position.x - transform.position.x) < maxDistance && Mathf.Abs(hit.transform.position.z - transform.position.z) < maxDistance)
                {
                    Portal portal = hit.transform.GetComponent<Portal>();
                    portal.LoadNextScene();
                }
            }

        }
    }
}