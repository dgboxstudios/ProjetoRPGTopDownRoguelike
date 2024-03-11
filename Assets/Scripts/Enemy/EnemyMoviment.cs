using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    #region Variaveis Private

    private StatusController statusController;

    #endregion

    #region Geral

    private void Start()
    {
        statusController = GetComponent<StatusController>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.player.transform.position, statusController.moveSpeed * Time.deltaTime);
    }

    #endregion

    #region Collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<StatusController>().Death(statusController.attackDamage);
            Destroy(gameObject);
        } 
    }

    #endregion
}
