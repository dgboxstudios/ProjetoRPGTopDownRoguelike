using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "New Weapon")]
public class Weapons : ScriptableObject
{
    [Header("Base Config")]
    [Space]
    public string weaponName;
    public int weaponPrice;
    public Sprite weaponIcon;
    public GameObject weaponProjectile;

    [Header("Status Config")]
    [Space]
    public float weaponDamage;
    public float weaponProjSpeed;
    public float weaponSpeed;
    public float weaponRange;
}
