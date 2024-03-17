using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    #region Variaveis

    public static HudManager Instance { get; private set; }

    [Header("HUD Reference")]
    [Space]
    public Slider lifeBar;
    public Slider expBar;
    public TMP_Text coinPrataText;
    public TMP_Text coinOuroText;
    public GameObject damagePopUp;

    [Space]
    [Header("Player Reference")]
    [Space]
    public StatusController statusController;

    #endregion

    #region Geral

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Update()
    {
        HUDController();
    }

    #endregion

    #region Informacoes HUD

    private void HUDController()
    {
        // HP
        lifeBar.maxValue = statusController.maxHp;
        lifeBar.value = statusController.currentHp;

        // EXP
        expBar.maxValue = InventoryManager.Instance.levelUp * 100;
        expBar.value = InventoryManager.Instance.currentExp;
    }

    #endregion
}
