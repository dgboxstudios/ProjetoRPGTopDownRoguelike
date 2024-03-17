using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region Variaveis Private

    public static InventoryManager Instance { get; private set; }

    [Header("LevelUp Configuration")]
    [Space]
    public int levelUp = 1;
    public int currentExp;

    [Header("Coin Configuration")]
    [Space]
    public int currentCoinPrata;
    public int currentCoinOuro;

    [Header("Itens Configuration")]
    [Space]
    public List<Weapons> weaponInventory;

    #endregion

    #region Geral

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        RefreshInventory();
    }

    private void Update()
    {
        
    }

    #endregion

    #region Inventory Configuration

    // Atualiza o inventario sempre que esta funcao e chamada
    private void RefreshInventory()
    {
        HudManager.Instance.coinPrataText.text = currentCoinPrata.ToString();
        HudManager.Instance.coinOuroText.text = currentCoinOuro.ToString();

        // Destri os slots antes de atualizar
        GameObject[] slotDestroy = GameObject.FindGameObjectsWithTag("Slot");
        foreach (GameObject goSlots in slotDestroy){ Destroy(goSlots); }

        foreach (Weapons weapon_ in weaponInventory)
        {
            GameObject newSlot = Instantiate(GameManager.Instance.invSlot, GameManager.Instance.invBackground.transform);
            
            if(weapon_ == null)
                newSlot.GetComponentInChildren<Image>().enabled = false;
            else
            {
                newSlot.GetComponentInChildren<Image>().enabled = true;
                newSlot.GetComponentInChildren<Image>().sprite = weapon_.weaponIcon;
            }
        }

        SelectWeapon();
    }

    // Destroi, seleciona e passa a arma e configuracoes da mesma para o jogador
    private void SelectWeapon()
    {
        if(GameManager.Instance.player.transform.childCount > 0)
            Destroy(GameManager.Instance.player.transform.GetChild(0).gameObject);

        Weapons toWeapon = weaponInventory[0];

        GameManager.Instance.player.GetComponent<StatusController>().projectile = toWeapon.weaponProjectile;
        GameManager.Instance.player.GetComponent<StatusController>().barrel = toWeapon.weaponBarrel;
        GameManager.Instance.player.GetComponent<StatusController>().projectileSpeed = toWeapon.weaponProjSpeed;
        GameManager.Instance.player.GetComponent<StatusController>().attackSpeed = toWeapon.weaponSpeed;
        GameManager.Instance.player.GetComponent<StatusController>().attackRange = toWeapon.weaponRange;
        GameManager.Instance.player.GetComponent<StatusController>().attackDamage = toWeapon.weaponDamage;

        Instantiate(GameManager.Instance.player.GetComponent<StatusController>().barrel, GameManager.Instance.player.gameObject.transform);
    }

    #endregion

    #region Exp

    public void ExpAdd(int expAdd_)
    {
        currentExp += expAdd_;
        if (currentExp >= levelUp * 100)
        {
            levelUp++;
            currentExp = 0;
        }
    }

    #endregion

    #region Gold

    public void GoldAdd(int currentCoinPrata_, int currentCoinOuro_)
    {
        currentCoinPrata += currentCoinPrata_;
        currentCoinOuro += currentCoinOuro_;
        RefreshInventory();
    }

    #endregion
}
