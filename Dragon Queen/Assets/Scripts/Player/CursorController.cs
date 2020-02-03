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

            if (Input.GetMouseButtonDown(0) && hit.transform.GetComponent<TreasureChest>())
            {

                TreasureChest chest = hit.transform.GetComponent<TreasureChest>();
                chest.Open(psm);
            }
            else if (Input.GetMouseButtonDown(0) && hit.transform.GetComponent<Interactive>())
            {
                Interactive interactive = hit.transform.GetComponent<Interactive>();
                interactive.Interact(psm);
            }
            else if (Input.GetMouseButtonDown(0) && hit.transform.GetComponent<Portal>())
            {
                Portal portal = hit.transform.GetComponent<Portal>();
                portal.LoadNextScene();
            }

        }
    }
}