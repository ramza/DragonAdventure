using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollow : MonoBehaviour
{
    public Transform playerTrans;
    public float minDistance = 4f;
    public float speed = 1f;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("fly", true);
    }

    void Update()
    {
        if (Mathf.Abs(playerTrans.position.x - transform.position.x) > minDistance || Mathf.Abs(playerTrans.position.z - transform.position.z) > minDistance)
        {
            anim.SetBool("fly", true);
            transform.LookAt(playerTrans);
            transform.position += transform.forward * speed * Time.deltaTime;

            RaycastHit hit;

            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, layerMask))
            {
    
                transform.position += Vector3.up * speed * Time.deltaTime; 
            }
            else
            {
 
            }
        }
        else{
            RaycastHit hit;
            int groundMask = 1 << 8;
            int waterMask = 1 << 4;
            //int layerMask = groundMask | waterMask;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, groundMask))
            {

            }
            else if(Physics.Raycast(transform.position, Vector3.down, out hit, 1f, waterMask))
            {
                transform.position += Vector3.down/3 * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.down * Time.deltaTime;
            }
            anim.SetBool("fly", false);
        }
    
    }

}
