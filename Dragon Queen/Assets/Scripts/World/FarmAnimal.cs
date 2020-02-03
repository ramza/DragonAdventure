using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimal : MonoBehaviour
{
    public enum FarmAnimalState
    {
        WALK, IDLE
    }

    private float timer;
    public float speed;
    public float idleDelay;
    public float walkDelay;
    CharacterController cc;
    Vector3 moveDirection;
    float gravitySpeed = 20f;

    FarmAnimalState fState;
    // Start is called before the first frame update
    void Start()
    {
        idleDelay += Random.Range(0, 2);
        walkDelay += Random.Range(-0.1f, 0.1f);
        cc = GetComponent<CharacterController>();
        fState = FarmAnimalState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (fState)
        {
            case FarmAnimalState.IDLE:
                Idle();
                break;
            case FarmAnimalState.WALK:
                Walk();
                break;

        }
    }

    void Idle()
    {
        timer += Time.deltaTime;
        if(timer > idleDelay)
        {
            fState = FarmAnimalState.WALK;
            timer = 0;
            return;
        }
        moveDirection = Vector3.zero;
        moveDirection.y -= gravitySpeed * Time.deltaTime; // Apply gravity
        cc.Move(moveDirection * Time.deltaTime);
    }

    void Walk()
    {
        if(timer == 0)
        {
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            moveDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(moveDirection);
            moveDirection *= speed;
        }

        timer += Time.deltaTime;

        if (timer > idleDelay)
        {
            timer = 0;
            fState = FarmAnimalState.IDLE;
            return;
        }

        moveDirection.y -= gravitySpeed * Time.deltaTime; // Apply gravity
        cc.Move(moveDirection * Time.deltaTime);
    }
}
