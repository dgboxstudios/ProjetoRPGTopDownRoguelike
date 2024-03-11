using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiled : MonoBehaviour
{
    #region Variaveis Private

    private Rigidbody2D rb2D;
    private Vector2 direction;
    private float projectileSpeed;
    private float attackRange;
    private float attackDamage;

    #endregion

    #region Geral

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, attackRange);
    }

    private void FixedUpdate()
    {
        // Vai na posicao que lhe e passada, neste caso a posicao do mouse
        rb2D.MovePosition(rb2D.position + direction * projectileSpeed * Time.fixedDeltaTime);
    }

    #endregion

    #region Configuration

    public void ConfigProjectiled(Vector2 direction_, float projectileSpeed_, float attackRange_, float attackDamage_)
    {
        direction = direction_;
        projectileSpeed = projectileSpeed_;
        attackRange = attackRange_;
        attackDamage = attackDamage_;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<StatusController>().Death(attackDamage);
            Destroy(gameObject);
        }
    }

    #endregion
}
