using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private enum DragonState
    {
        IDLE, WALK, FLY, ATTACK
    }

    DragonState dState;
    public ParticleSystem dragonFire;
    DragonGroundController groundController;
    BasicFlight airController;
    BasicFollow basicFollow;
    HideTiles hideTiles;
    public GameObject rider;
    CharacterController cc;
    GameObject player;

    Animator anim;

    private float timer;
    private float inputDelay = 1f;


    private float fireTimer;
    private float cookDelay = 0.1f;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        cc = GetComponent<CharacterController>();
        airController = GetComponent<BasicFlight>();
        groundController = GetComponent<DragonGroundController>();
        hideTiles = GetComponent<HideTiles>();
        basicFollow = GetComponent<BasicFollow>();
        player = GameObject.FindGameObjectWithTag("Player");
        dState = DragonState.IDLE;
        dragonFire.Stop();
    }

    void Update()
    {
        switch (dState)
        {
            case DragonState.IDLE:

                //anim.SetBool("fly", true);
                break;
            case DragonState.WALK:
                timer += Time.deltaTime;

                var v = Input.GetAxis("Vertical");
                if ( v== 0)
                {
                    anim.SetBool("walk", false);
                }
                else
                {
                    anim.SetBool("walk", true);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("fly", true);
                    cc.Move(Vector3.up * 4f);
                    dState = DragonState.FLY;
                    airController.enabled = true;
                    groundController.enabled = false;
                }
                else if (Input.GetKeyDown(KeyCode.R) && timer > inputDelay)
                {
                    anim.SetBool("walk", false);
                    DisableDragonControls();
                }
                
                else if (Input.GetMouseButton(0))
                {
                    groundController.canMove = false;
                    dState = DragonState.ATTACK;
                    anim.SetBool("attack", true);
                    dragonFire.Play();
                    timer = 0;
                }
                break;
            case DragonState.FLY:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("fly", false);
                    dState = DragonState.WALK;
                    airController.enabled = false;
                    transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));
                    groundController.enabled = true;
                }
                GroundCheck();
                WaterCheck();
                break;
            case DragonState.ATTACK:
                timer += Time.deltaTime;

                if (!Input.GetMouseButton(0))
                {
                    groundController.canMove = true;
                    anim.SetBool("attack", false);
                    dState = DragonState.WALK;
                    dragonFire.Stop();
                }
                else if(timer > cookDelay)
                {
                    timer = 0;
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
                    {
                        print("hit a " + hit.transform.name);
                        if (hit.transform.tag == "Enemy")
                        {

                            Transform objectHit = hit.transform;
                            Vector3 direction = (objectHit.position - transform.position).normalized;
                            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
                            transform.rotation = lookRotation;


                            objectHit.GetComponent<EnemyHealthManager>().Hurt(2f);


                        }

                        // Do something with the object that was hit by the raycast.
                    }
                }
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
    }

    public void WaterCheck()
    {
        int layerMask = 1 << 4;
        RaycastHit groundRay;
        if (Physics.Raycast(transform.position, Vector3.down, out groundRay, 1f, layerMask))
        {
            DisableDragonControls();
        }
    }

    public void DisableDragonControls()
    {
        anim.SetBool("walk", false);
        anim.SetBool("fly", false);
        dState = DragonState.IDLE;
        hideTiles.enabled = false;
        groundController.enabled = false;
        airController.enabled = false;
        rider.SetActive(false);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));
        player.transform.position = transform.position + Vector3.right * 2f;
        player.transform.rotation = transform.rotation;
        player.GetComponent<ThirdPersonController>().enabled = true;
        player.SetActive(true);
        basicFollow.enabled = true;
    }

    public void ActivateDragon()
    {
        timer = 0;
        cc.Move(Vector3.up * 1f);
        groundController.enabled = true;
        hideTiles.enabled = true;
        dState = DragonState.WALK;
        rider.SetActive(true);
        basicFollow.enabled = false;
        if (!groundController.canMove)
        {
            groundController.canMove = true;
        }
    }
}
