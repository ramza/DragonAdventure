using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectsInTile : MonoBehaviour
{

    [SerializeField]
    private string objectsTag = "Enemy";
    public Transform player;
    GameObject[] objectsToCheck;

    public float maxDistance = 40f;
    public float timer = 0;
    public float delay= 0.1f;
    void Awake()
    {
        objectsToCheck = GameObject.FindGameObjectsWithTag(objectsTag);
        
    }

    public void DeactivateDistantObjects()
    {
        Vector3 currentPosition = player.position;

        foreach (GameObject go in objectsToCheck)
        {
            if(go == null)
            {
                return;
            }
            Vector3 tilePosition = go.gameObject.transform.position;

            float xDistance = Mathf.Abs(tilePosition.x - currentPosition.x);
            float zDistance = Mathf.Abs(tilePosition.z - currentPosition.z);

            if (xDistance > maxDistance || zDistance > maxDistance)
            {
                go.SetActive(false);
            }
            else
            {
                go.SetActive(true);
            }
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.25f)
        {
            timer = 0;
            DeactivateDistantObjects();
        }
    }
}