using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerState playerState;

    PlayerIdleState playerIdleState = new PlayerIdleState();
    PlayerRunState playerRunState = new PlayerRunState();
    PlayerJumpState playerJumpState = new PlayerJumpState();
    PlayerAttackState playerAttackState = new PlayerAttackState();
    PlayerDeadState playerDeadState = new PlayerDeadState();
    PlayerBlockState playerBlockState = new PlayerBlockState();
    public ThirdPersonController thirdPersonController;
    CharacterStats stats;
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
        stats = GetComponent<CharacterStats>();
        camera = Camera.main;
        _anim = GetComponentInChildren<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        playerState = playerIdleState;
    }

    // Update is called once per frame
    void FixedUpdate()
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
        if (!thirdPersonController.canMove)
        {
            return;
        }
        var v = Input.GetAxis("Vertical");

        if (v != 0)
        {
            GotoRun();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(playerJumpState);
        }

        if ((Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) || Input.GetKey(KeyCode.F))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Interactive" || hit.transform.tag == "Chest")
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

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.F))
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

    public void EnterWater()
    {
        _anim.SetBool("swim", true);
    }


    public void ExitWater()
    {
        _anim.SetBool("swim", false);
    }

    public void Attack()
    {
        if(timer == 0)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10f))
            {
                if(hit.transform.tag == "Enemy")
                {
                    if(Mathf.Abs(hit.transform.position.x - transform.position.x) < 5f && Mathf.Abs(hit.transform.position.z - transform.position.z) < 5f)
                    {
                        Transform objectHit = hit.transform;
                        Vector3 direction = (objectHit.position - transform.position).normalized;
                        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
                        transform.rotation = lookRotation;
                    }


                }
                else if (hit.transform.tag == "Breakable")
                {
                    if (Mathf.Abs(hit.transform.position.x - transform.position.x) < 2f && Mathf.Abs(hit.transform.position.z - transform.position.z) < 2f)
                    {
                        Transform objectHit = hit.transform;
                        Vector3 direction = (objectHit.position - transform.position).normalized;
                        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
                        transform.rotation = lookRotation;
                        print("hit a pot.");
                        hit.transform.GetComponent<BreakableObject>().TakeDamage(stats.CalculateDamage());
                    }
                }
            }


            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
     
                if (hit.transform.tag == "Enemy")
                {

                        Transform objectHit = hit.transform;
                        Vector3 direction = (objectHit.position - transform.position).normalized;
                        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
                        transform.rotation = lookRotation;


                    objectHit.GetComponent<EnemyHealthManager>().Hurt(stats.CalculateDamage());


                } else if ( hit.transform.tag == "Breakable")
                {
                    Transform objectHit = hit.transform;
                    Vector3 direction = (objectHit.position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
                    transform.rotation = lookRotation;
                    print("hit a pot.");
                    hit.transform.GetComponent<BreakableObject>().TakeDamage(stats.CalculateDamage());
                }

            }
        }

        timer += Time.deltaTime;

        if ( timer > 0.5f)
        {
            ChangeState(playerIdleState);
        }

    }

    public void Block()
    {

    }

    public void SetIldeState()
    {
        ChangeState(playerIdleState);
    }

    public void Revive()
    {
        thirdPersonController.canMove = true;
        ChangeState(playerIdleState);
    }

    public void KillPlayer()
    {
        ChangeState(playerDeadState);
    }
}