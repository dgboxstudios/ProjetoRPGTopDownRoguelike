using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemStore : MonoBehaviour
{
    [Header("Reference Config")]
    [Space]
    public Weapons weapons;
    public Image iconHolder;
    public TMP_Text nameHolder;
    public TMP_Text priceHolder;
    public TMP_Text infoHolder;
    public Button isPriceButton;

    private void Start()
    {
        Store(weapons);
    }

    private void Update()
    {
        RefreshItem();
    }

    public void Store(Weapons weapons_)
    {
        iconHolder.sprite = weapons_.weaponIcon;
        nameHolder.text = weapons_.weaponName.ToString();
        priceHolder.text = weapons_.weaponPrice.ToString();
        infoHolder.text = "Damage: " + weapons_.weaponDamage.ToString() + "\nSpeed: " + weapons_.weaponSpeed.ToString() + "\nRange: " + weapons_.weaponRange.ToString();

        if (InventoryManager.Instance.currentCoin < weapons_.weaponPrice)
            isPriceButton.interactable = false;
        else
            isPriceButton.interactable = true;
    }

    public void BuyWeapon()
    {
        InventoryManager.Instance.weaponInventory[0] = null;
        InventoryManager.Instance.weaponInventory[0] = weapons;
        InventoryManager.Instance.GoldAdd(weapons.weaponPrice * -1);

        //RefreshItem();
        Destroy(gameObject);
    }

    private void RefreshItem()
    {
        GameObject[] item = GameObject.FindGameObjectsWithTag("ItemStore");
        foreach (GameObject goItem in item)
        {
            goItem.GetComponent<ItemStore>().Store(goItem.GetComponent<ItemStore>().weapons);
        }
    }
}
