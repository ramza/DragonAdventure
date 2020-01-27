using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private enum DragonState
    {
        IDLE, WALK, FLY
    }

    DragonState dState;

    DragonGroundController groundController;
    BasicFlight airController;
    BasicFollow basicFollow;
    HideTiles hideTiles;
    public GameObject rider;

    GameObject player;
    private float timer;
    private float inputDelay = 1f;
    void Start()
    {
        airController = GetComponent<BasicFlight>();
        groundController = GetComponent<DragonGroundController>();
        hideTiles = GetComponent<HideTiles>();
        basicFollow = GetComponent<BasicFollow>();
        player = GameObject.FindGameObjectWithTag("Player");
        dState = DragonState.IDLE;
    }

    void Update()
    {
        switch (dState)
        {
            case DragonState.WALK:
                timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dState = DragonState.FLY;
                    airController.enabled = true;
                    groundController.enabled = false;
                }
                else if (Input.GetKeyDown(KeyCode.R) && timer > inputDelay)
                {
                    DisableDragonControls();
                }
                break;
            case DragonState.FLY:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dState = DragonState.WALK;
                    airController.enabled = false;
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                    groundController.enabled = true;
                }
                GroundCheck();
                break;
        }

    }

    public void GroundCheck()
    {
        int layerMask = 1 << 8;
        RaycastHit groundRay;

        if (Physics.Raycast(transform.position, Vector3.down, out groundRay, 1f, layerMask))
        {
            DisableDragonControls();
        }

        layerMask = 1 << 4;
        if (Physics.Raycast(transform.position, Vector3.down, out groundRay, 1f, layerMask))
        {
            DisableDragonControls();
        }
    }

    public void DisableDragonControls()
    {
        dState = DragonState.IDLE;
        hideTiles.enabled = false;
        groundController.enabled = false;
        airController.enabled = false;
        rider.SetActive(false);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        player.transform.position = transform.position + Vector3.right * 2f;
        player.GetComponent<ThirdPersonController>().enabled = true;
        player.SetActive(true);
        basicFollow.enabled = true;
    }

    public void ActivateDragon()
    {
        timer = 0;
        transform.position += Vector3.up * 2f;
        groundController.enabled = true;
        hideTiles.enabled = true;
        dState = DragonState.WALK;
        rider.SetActive(true);
        basicFollow.enabled = false;
    }
}
