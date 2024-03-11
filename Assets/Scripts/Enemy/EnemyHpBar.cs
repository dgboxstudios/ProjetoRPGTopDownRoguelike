using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    #region Variaveis Private

    private StatusController statusController;
    private Slider hpBar;

    #endregion

    #region Geral

    private void Start()
    {
        statusController = GetComponentInParent<StatusController>();
        hpBar = gameObject.GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        AttHpBar();
    }

    #endregion

    #region Atualiza HP Bar

    private void AttHpBar()
    {
        hpBar.maxValue = statusController.maxHp;
        hpBar.value = statusController.currentHp;
    }

    #endregion
}
