using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public List<GameObject> hearts;
    public GameObject healthIconCell;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public float iconSize = 16;
    Vector3 startPosition;

    public void Start()
    {
        startPosition = healthIconCell.transform.position;
        healthIconCell.SetActive(false);
    }

    public void ClearHearts()
    {
        if ( hearts.Count > 0)
        {

        }
    }


    public void UpdatePlayerHealth(float curHP, float maxHP)
    {
        while (hearts.Count < maxHP / 2)
        {
            GameObject cell = Instantiate(healthIconCell, startPosition, Quaternion.identity, transform);
            cell.GetComponent<Image>().sprite = emptyHeart;
            hearts.Add(cell);
        }

        ClearHearts();

        float fullHearts = (int)curHP / 2;
        float halfHearts = curHP % 2;
        float emptyHearts = (int)(maxHP - curHP) / 2;

        int totalHearts = 0;
        for (int i = 0; i < fullHearts; i++)
        {

            GameObject cell = hearts[totalHearts];
            cell.GetComponent<Image>().sprite = fullHeart;
            hearts.Add(cell);
            totalHearts += 1;
        }

        if(halfHearts == 1)
        {
            GameObject cell = hearts[totalHearts];
            cell.GetComponent<Image>().sprite = halfHeart;
            hearts.Add(cell);
            totalHearts += 1;
        }

        for (int i = 0; i < emptyHearts; i++)
        {

            GameObject cell = hearts[totalHearts];
            cell.GetComponent<Image>().sprite = emptyHeart;
            hearts.Add(cell);
            totalHearts += 1;
        }

    }
}
