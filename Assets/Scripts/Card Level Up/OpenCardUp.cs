using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardUp : MonoBehaviour
{
    #region Card List

    // Lista das cartas
    public List<CardLvlUp> cardUpSold;

    #endregion

    #region Geral

    private void Start()
    {
        RandomItemCard();
        GameManager.Instance.cardUI.SetActive(false);
    }

    #endregion

    #region Random/Refresh Card

    // Sorteia 3 cartas a serem selecionadas
    public void RandomItemCard()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomWeapon = Random.Range(0, cardUpSold.Count);
            GameObject newItemStore = Instantiate(GameManager.Instance.cardItem, GameManager.Instance.cardUI.transform);
            newItemStore.GetComponent<ItemCard>().cardLvlUp = cardUpSold[randomWeapon];
            newItemStore.GetComponent<ItemCard>().Card(cardUpSold[randomWeapon]);
        }
    }

    // Atualiza as cartas destruindo elas antes de serem sortiadas e criadas de novo
    public void RefreshItemCard()
    {
        GameObject[] slotDestroy = GameObject.FindGameObjectsWithTag("CardSlot");
        foreach (GameObject goSlots in slotDestroy) { Destroy(goSlots); }
    }

    #endregion
}
