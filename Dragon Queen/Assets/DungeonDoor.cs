using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour
{
    public GameObject door;
    public Material hoverMat;
    private Material startMat;
    MeshRenderer meshRend;

    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        startMat = meshRend.material;
    }
    private void OnMouseDown()
    {
        door.SetActive(false);
    }

    public void OnMouseEnter()
    {
        meshRend.material = hoverMat;
    }

    public void OnMouseExit()
    {
        meshRend.material = startMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
