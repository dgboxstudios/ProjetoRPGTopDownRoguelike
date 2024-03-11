using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    #region Reference

    [Header("Spawn/Enemys Ref")]
    [Space]
    public List<GameObject> spawnPoints;
    public List<GameObject> enemys;

    [Space]
    [Header("Door Active")]
    [Space]
    public GameObject doorActive;

    [Space]
    [Header("Chance in Percentage")]
    [Space]
    public float isPercentage;

    #endregion

    #region Variaveis Private

    private int enemyActive;
    private bool dungeonActive;
    private bool isInstanceEnemy;

    #endregion

    #region Verifica Colisao, Spawn e Checa Inimigos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnEnemy();
            dungeonActive = true;
        }
    }

    private void SpawnEnemy()
    {
        foreach (GameObject sp in spawnPoints)
        {
            int randomEnemy = Random.Range(0, enemys.Count);

            GameObject newEnemy = Instantiate(enemys[randomEnemy], sp.transform.position, Quaternion.identity);
            newEnemy.GetComponent<StatusController>().spawnEnemys = this;
            enemyActive++;
        }
    }

    public void CheckEnemyActive()
    {
        enemyActive--;

        if(dungeonActive)
            if(enemyActive == 0)
            {
                if(Random.value < isPercentage && !isInstanceEnemy) // Tem 30% de chanse de dar spawn novamente nos inimigos
                {
                    isInstanceEnemy = true;
                    SpawnEnemy();
                }
                else if(doorActive != null)
                    doorActive.SetActive(true);

                if (enemyActive == 0)
                    GameManager.Instance.cardUI.SetActive(true);
            }
    }

    #endregion
}
