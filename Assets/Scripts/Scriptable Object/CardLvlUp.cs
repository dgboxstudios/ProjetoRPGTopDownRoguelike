using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card UP", menuName = "New Card Up")]
public class CardLvlUp : ScriptableObject
{
    [Header("Base Config")]
    [Space]
    public string cardName;
    public Sprite cardIcon;
    public string cardInfo;

    [Header("Status Config")]
    [Space]
    public string cardNameBonus;
    public float cardValueBonus;
}
