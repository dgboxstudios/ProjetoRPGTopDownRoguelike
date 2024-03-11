using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCard : MonoBehaviour
{
    #region Reference

    [Header("Reference Config")]
    [Space]
    public CardLvlUp cardLvlUp;
    public Image iconHolder;
    public TMP_Text nameHolder;
    public TMP_Text infoHolder;
    public Button isPriceButton;

    #endregion

    #region Variaveis Private

    private string cardNameBonusHolder;
    private float cardValueBonusHolder;

    #endregion

    #region Card

    // Recebe a carta sortiada e passa as informacoes para as variaveis
    public void Card(CardLvlUp cardup)
    {
        iconHolder.sprite = cardup.cardIcon;
        nameHolder.text = cardup.cardName.ToString();
        infoHolder.text = cardup.cardInfo.ToString();
        cardNameBonusHolder = cardup.cardNameBonus;
        cardValueBonusHolder = cardup.cardValueBonus;
    }

    #endregion

    #region Select Card

    // Apos clicar no botatao da carta selecionada, ela passa as melhorias para o jogador
    public void SelectCard()
    {
        if (cardNameBonusHolder == "AddHp") // Add HP
        {
            GameManager.Instance.player.GetComponent<StatusController>().maxHp += cardValueBonusHolder;
            GameManager.Instance.player.GetComponent<StatusController>().currentHp += cardValueBonusHolder;
        }
        else if (cardNameBonusHolder == "AddMoveSpeed") // Add velocidade de movimento
            GameManager.Instance.player.GetComponent<StatusController>().moveSpeed += cardValueBonusHolder;

        else if (cardNameBonusHolder == "AddAttackDamage") // Add mais pontos de ataque
            GameManager.Instance.player.GetComponent<StatusController>().bonusAttackDamage += cardValueBonusHolder;
        
        else if (cardNameBonusHolder == "AddAttackSpeed") // Add mais velocidade ao ataque
            GameManager.Instance.player.GetComponent<StatusController>().bonusAttackSpeed += cardValueBonusHolder;

        else if (cardNameBonusHolder == "AddAttackRange") // Add mais distancia ao projetil
            GameManager.Instance.player.GetComponent<StatusController>().bonusAttackRange += cardValueBonusHolder;
        
        else if (cardNameBonusHolder == "AddDashMove") // Add mais distancia ao dash
            GameManager.Instance.player.GetComponent<StatusController>().bonusDashMove += cardValueBonusHolder;
        
        else if (cardNameBonusHolder == "AddDashCooldown") // Add menos tempo para execultar novamente o dash
            GameManager.Instance.player.GetComponent<StatusController>().bonusDasnCooldown += cardValueBonusHolder;


        // Resorteia e desativa seletor de cartas
        GameManager.Instance.cardRamdom.GetComponent<OpenCardUp>().RefreshItemCard();
        GameManager.Instance.cardRamdom.GetComponent<OpenCardUp>().RandomItemCard();
        GameManager.Instance.cardUI.SetActive(false);
    }

    #endregion
}
