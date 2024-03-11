using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Variaveis Private

    private StatusController statusController;
    private bool isAttack = true;
    private float currentTime;

    #endregion

    #region Geral

    private void Start()
    {
        statusController = GetComponent<StatusController>();
    }

    private void Update()
    {
        Attack();
    }

    #endregion

    #region Attack

    // Utilizado para atirar
    private void Attack()
    {
        Cooldown();

        if (Input.GetMouseButton(0) && isAttack)
        {
            // Calcula a posicao do mouse e atira nessa posicao
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mousePosition.Normalize();

            GameObject newProjectiled = Instantiate(statusController.projectile, transform.position, Quaternion.identity);
            newProjectiled.GetComponent<Projectiled>().ConfigProjectiled(mousePosition, statusController.projectileSpeed, statusController.attackRange, statusController.attackDamage * ((statusController.bonusAttackDamage + 100) / 100));

            isAttack = false;
            currentTime = 0;
        }
    }

    // Utilizado como cronometro para saber se ja pode atirar novamente
    private void Cooldown()
    {
        if (currentTime >= (statusController.attackSpeed * ((100 - statusController.bonusAttackSpeed)) / 100) && !isAttack)
            isAttack = true;
        else
            currentTime += Time.deltaTime;
    }

    #endregion
}
