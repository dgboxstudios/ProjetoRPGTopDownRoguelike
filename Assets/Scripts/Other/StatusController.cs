using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    #region Configuration Status

    [Header("Base Configuration")]
    [Space]
    public float baseSpeed;
    public float moveSpeed;
    public float maxHp;
    public float currentHp;
    public float baseDash;
    public float moveDash;
    public int expAdd;
    public GameObject dropCoinPrata;
    public GameObject dropCoinOuro;

    [Space]
    [Header("Attack Configuration")]
    [Space]
    public GameObject projectile;
    public GameObject barrel;
    public float projectileSpeed;
    public float attackSpeed;
    public float attackRange;
    public float attackDamage;

    [Space]
    [Header("Card Bonus Configuration")]
    [Space]
    public float bonusAttackDamage;
    public float bonusAttackSpeed;
    public float bonusAttackRange;
    public float bonusDashMove;
    public float bonusDasnCooldown;

    [Space]
    [Header("Spawn Enemy Ref")]
    [Space]
    public SpawnEnemys spawnEnemys;

    [Space]
    [Header("Chance in Percentage Gold")]
    [Space]
    public float isPercentagePrata;
    public float isPercentageOuro;

    #endregion

    #region Geral

    private void Start()
    {
        moveSpeed = baseSpeed;
        currentHp = maxHp;
        moveDash = baseDash;
    }

    #endregion

    #region Detector de Death, Inimigo e Jogador

    public void Death(float damage_)
    {
        currentHp -= damage_;
        GameObject newDamagePopUp = Instantiate(HudManager.Instance.damagePopUp, gameObject.transform.position, Quaternion.identity);
        newDamagePopUp.GetComponentInChildren<TMP_Text>().text = damage_.ToString();
        newDamagePopUp.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1.5f, 1.5f), 4f), ForceMode2D.Impulse);
        Destroy(newDamagePopUp, .4f);

        if (currentHp <= 0 && gameObject.tag == "Player")
            Debug.Log("Gameover");
        else if(currentHp <= 0 && gameObject.tag == "Enemy")
        {
            spawnEnemys.CheckEnemyActive();
            InventoryManager.Instance.ExpAdd(expAdd);

            if (Random.value < isPercentagePrata) // Tem 30% de chanse de dropar moeda de prata
                Instantiate(dropCoinPrata, transform.position, Quaternion.identity);
            else if (Random.value < isPercentageOuro)// Tem 10% de chanse de dropar moeda de ouro
                Instantiate(dropCoinOuro, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    #endregion
}
