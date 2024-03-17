using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGold : MonoBehaviour
{
    [Header("Drop Gold Prata Config")]
    [Space]
    public int maxDropGoldPrata;
    public int minDropGoldPrata;

    [Space]
    [Header("Drop Gold Ouro Config")]
    [Space]
    public int dropGoldOuro;

    private int goldPrata;

    private void Start()
    {
        RandomGold();
    }

    private void RandomGold()
    {
        if (minDropGoldPrata > 0)
        {
            int randomGoldPrata = Random.Range(minDropGoldPrata, maxDropGoldPrata);
            goldPrata = randomGoldPrata;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InventoryManager.Instance.GoldAdd(goldPrata, dropGoldOuro);
            Destroy(gameObject);
        }
    }
}
