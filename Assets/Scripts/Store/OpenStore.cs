using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    public List<Weapons> weaponsSold;

    private void Start()
    {
        RandomItemStore();
        GameManager.Instance.shopUI.SetActive(false);
    }

    private void Update()
    {
        OpenStoreController();
    }

    private void OpenStoreController()
    {
        float distance = Vector2.Distance(transform.position, GameManager.Instance.player.transform.position);
        if (distance < 1)
        {
            GameManager.Instance.shopText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
                GameManager.Instance.shopUI.SetActive(true);
        }
        else
        {
            GameManager.Instance.shopText.SetActive(false);
            GameManager.Instance.shopUI.SetActive(false);
        }
    }

    public void RandomItemStore()
    {
        for (int i = 0; i < 4; i++)
        {
            int randomWeapon = Random.Range(0, weaponsSold.Count);
            GameObject newItemStore = Instantiate(GameManager.Instance.shopItem, GameManager.Instance.shopUI.transform);
            newItemStore.GetComponent<ItemStore>().weapons = weaponsSold[randomWeapon];
            newItemStore.GetComponent<ItemStore>().Store(weaponsSold[randomWeapon]);
        }
    }
}
