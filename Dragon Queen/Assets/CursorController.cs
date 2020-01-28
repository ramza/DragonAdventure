using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{
    public Camera camera;

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            print(hit.transform.name);
            // Do something with the object that was hit by the raycast.
        }
    }
}