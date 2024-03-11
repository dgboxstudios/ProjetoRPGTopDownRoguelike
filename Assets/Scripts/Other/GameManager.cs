using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Reference Player")]
    [Space]
    public GameObject player;

    [Space]
    [Header("Reference Inventory")]
    [Space]
    public GameObject invBackground;
    public GameObject invSlot;

    [Space]
    [Header("Reference Shop")]
    [Space]
    public GameObject shopText;
    public GameObject shopUI;
    public GameObject shopItem;

    [Space]
    [Header("Reference Card Lvl Up")]
    [Space]
    public GameObject cardUI;
    public GameObject cardItem;
    public GameObject cardRamdom;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        Application.targetFrameRate = 60;
    }
}
