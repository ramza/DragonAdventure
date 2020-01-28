using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerState playerState;

    PlayerIdleState playerIdleState = new PlayerIdleState();
    PlayerRunState playerRunState = new PlayerRunState();
    PlayerJumpState playerJumpState = new PlayerJumpState();
    PlayerAttackState playerAttackState = new PlayerAttackState();
    public ThirdPersonController thirdPersonController;
    public Animator _anim;
    Camera camera;

    float timer = 0;
    public void ResetTimer()
    {
        timer = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        _anim = GetComponentInChildren<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        playerState = playerIdleState;
    }

    // Update is called once per frame
    void Update()
    {
        playerState.Update(this);
    }

    void ChangeState(PlayerState newState)
    {
        playerState.Exit(this);
        playerState = newState;
        playerState.Enter(this);
    }

    public void GotoRun()
    {
        ChangeState(playerRunState);
    }

    public void GotoIdle()
    {
        ChangeState(playerIdleState);
    }

    public void Idle()
    {
        var v = Input.GetAxis("Vertical");

        if (v != 0)
        {
            GotoRun();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(playerJumpState);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Interactive")
                {
                    return;
                }
            }
            ChangeState(playerAttackState);
        }
    }

    public void OnEnable()
    {
        playerState = playerIdleState;
    }

    public void Run()
    {
        var v = Input.GetAxis("Vertical");

        if (v == 0)
        {
            GotoIdle();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(playerJumpState);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Interactive")
                {
                    return;
                }
            }
            ChangeState(playerAttackState);
        }
    }

    public void Jump()
    {
        timer += Time.deltaTime;
        if ( timer > 0.2f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                //print("hit something");
                GotoIdle();
            }
        }
    }

    public void Attack()
    {
        timer += Time.deltaTime;

        if ( timer > 0.5f)
        {
            ChangeState(playerIdleState);
        }
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