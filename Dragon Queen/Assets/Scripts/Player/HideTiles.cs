using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTiles : MonoBehaviour
{

    [SerializeField]
    private string tileTag;

    [SerializeField]
    private Vector3 tileSize;

    [SerializeField]
    private int maxDistance;

    private GameObject[] tiles;
    private float timer;

    // Use this for initialization
    void Start()
    {

        InitTiles();
        DeactivateDistantTiles();
  
    }

    public void InitTiles()
    {
        this.tiles = GameObject.FindGameObjectsWithTag(tileTag);
    }

    public void DeactivateDistantTiles()
    {
        Vector3 playerPosition = this.gameObject.transform.position;

        foreach (GameObject tile in tiles)
        {
            Vector3 tilePosition = tile.gameObject.transform.position;

            float xDistance = Mathf.Abs(tilePosition.x - playerPosition.x);
            float zDistance = Mathf.Abs(tilePosition.z - playerPosition.z);

            if (xDistance > maxDistance || zDistance > maxDistance)
            {
                tile.SetActive(false);
            }
            else
            {
                tile.SetActive(true);
            }
        }
    }

    void Update()
    {
            timer += Time.deltaTime;
            if (timer > 0.25f)
            {
                timer = 0;
                DeactivateDistantTiles();
            }
    }

}