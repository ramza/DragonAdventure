using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollow : MonoBehaviour
{
    public Transform playerTrans;
    public float minDistance = 4f;
    public float speed = 1f;


    void Update()
    {
        if (Mathf.Abs(playerTrans.position.x - transform.position.x) > minDistance || Mathf.Abs(playerTrans.position.z - transform.position.z) > minDistance)
        {
            transform.LookAt(playerTrans);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    
    }

}
