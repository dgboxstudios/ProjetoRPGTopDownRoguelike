using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGold : MonoBehaviour
{
    [Header("Drop Gold Config")]
    [Space]
    public int maxDropGold;
    public int minDropGold;

    private int gold;

    private void Start()
    {
        int randomGold = Random.Range(minDropGold, maxDropGold);
        gold = randomGold;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InventoryManager.Instance.GoldAdd(gold);
            Destroy(gameObject);
        }
    }
}
