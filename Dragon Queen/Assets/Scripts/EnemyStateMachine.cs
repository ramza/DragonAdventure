using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{

    public CharacterController controller;
    Vector3 moveDirection = Vector3.zero;
    public float moveDirectionSpeed = 1.0f;
    private EnemyState enemyState;
    private EnemyIdleState enemyIdleState = new EnemyIdleState();
    private EnemyRunState enemyRunState = new EnemyRunState();
    private EnemyChaseState enemyChaseState = new EnemyChaseState();
    private EnemyDeadState enemyDeadState = new EnemyDeadState();
    private EnemyAttackState enemyAttackState = new EnemyAttackState();

    public float turnSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravitySpeed = 20.0f;

    public Animator anim;
    public Transform rayOrigin;
    public Transform currentTarget;

    public float chaseRange = 3f;
    public float attackRange = 1f;
    public GameObject player;
    public float timer;
    private bool hasTarget;
    private bool canAttack;
    public float attackTime = 1f;
    public float attackRayLength = 10f;

    public float idleTimer;
    public float idleTime = 4f;
    public float walkTime = 1f;

    private bool targetIsDead = false;
    private EnemyStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        idleTime += Random.Range(0, 2);
        walkTime += Random.Range(-0.1f, 0.1f);
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyStats = GetComponent<EnemyStats>();
        // initialize state
        enemyState = enemyIdleState;

    }

    private void ChangeState(EnemyState newState)
    {
        enemyState.Exit(this);
        enemyState = newState;
        enemyState.Enter(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyState.Update(this);
    }

    public void Run()
    {
        if ( timer == 0)
        {
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            moveDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(moveDirection);
            moveDirection *= moveDirectionSpeed;
        }

        timer += Time.deltaTime;
        if ( timer > walkTime)
        {
            ChangeState(enemyIdleState);
        }

        moveDirection.y -= gravitySpeed * Time.deltaTime; // Apply gravity
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Idle()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < chaseRange && Mathf.Abs(player.transform.position.z - transform.position.z) < chaseRange)
        {
            if (!targetIsDead)
            {
                ChangeState(enemyChaseState);
                return;
            }
 
        }

        idleTimer += Time.deltaTime;

        if (idleTimer > idleTime)
        {
            targetIsDead = false;
            ChangeState(enemyRunState);
            return;
        }

        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            
        }

        moveDirection = Vector3.zero;
        moveDirection.y -= gravitySpeed * Time.deltaTime; // Apply gravity
        controller.Move(moveDirection * Time.deltaTime);
    }

    void EnemyAttackRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRayLength))
        {

            if ( hit.transform.tag == "Player")
            {
  
                if ( hit.transform.GetComponent<CharacterStats>().curHP <= 0)
                {
                    targetIsDead = true;
                }
                print("hit something with the goblin attack");
                hit.transform.GetComponent<PlayerHealthManager>().TakeDamage(enemyStats.baseAttackBonus);
            }
        }
    }


    public void Attack()
    {
        if (!player.activeInHierarchy)
        {
            ChangeState(enemyRunState);
            return;
        }

        if ( canAttack)
        {
            print("goblin attack!");
            EnemyAttackRay();
            currentTarget = player.transform;
            RotateTowards(currentTarget);
            canAttack = false;
        }

        if (targetIsDead)
        {

            print("change to enemy run state");
            ChangeState(enemyRunState);
            return;
        }

        timer += Time.deltaTime;
        if ( timer > attackTime/2)
        {
            anim.SetBool("attack", false);
        }

        if ( timer > attackTime)
        {
            timer = 0;
            canAttack = true;
 
            anim.SetBool("attack", true);
 
         
            RotateTowards(currentTarget);

            if (currentTarget == null)
            {
                //hasTarget = false;
                //ChangeState(enemyIdleState);
                return;
            }

            else if (Mathf.Abs(currentTarget.transform.position.x - transform.position.x) > attackRange+1 || Mathf.Abs(currentTarget.transform.position.z - transform.position.z) > attackRange+1)
            {
                print("go to chase!");
                ChangeState(enemyChaseState);
                return;
            }
        }

        moveDirection = Vector3.zero;
        moveDirection.y -= gravitySpeed * Time.deltaTime; // Apply gravity
        controller.Move(moveDirection * Time.deltaTime);

    }


    public void Chase()
    {
        if (!player.activeInHierarchy)
        {
            ChangeState(enemyRunState);
            return;
        }

        if (Mathf.Abs(player.transform.position.x - transform.position.x) < attackRange && Mathf.Abs(player.transform.position.z - transform.position.z) < attackRange)
        {
            print("goto enemy attack state");
            ChangeState(enemyAttackState);
            return;
        }
        else if (Mathf.Abs(player.transform.position.x - transform.position.x) > chaseRange && Mathf.Abs(player.transform.position.z - transform.position.z) > chaseRange)
        {
            ChangeState(enemyIdleState);
            return;
        }
        else
        {
            moveDirection = player.transform.position - transform.position;
            moveDirection = moveDirection.normalized;
            moveDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(moveDirection);
            moveDirection *= moveDirectionSpeed;
            moveDirection.y -= gravitySpeed * Time.deltaTime; // Apply gravity
            controller.Move(moveDirection * Time.deltaTime);
        }

    }

    private void RotateTowards(Transform target)
    {
        if (target == null)
        {
            return;
        }
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        transform.rotation = lookRotation;
    }


    public void Kill()
    {
        ChangeState(enemyDeadState);
    }

    public void Dead()
    {

    }
}
