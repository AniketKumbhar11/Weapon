using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/CreateWeapon")]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public enum _weaponType
    {   
        
        Rifle,
        Pistol,
        Shotgun,
        Sniper,
        Assault,
        Marksman,
        Grenade,
        Knife,
        Bullets,
        Stun,
        Plasma
    }
    public _weaponType WeaponType;
    public string WeaponName;
    public GameObject WeaponPrefab;
    public Sprite WireWeaponImage;
    public Sprite SpriteIcon;
    [Range(0,10)]
    public int Weigth;
    [Range(0, 10)]
    public int Accuracy;
    [Range(0, 10)]
    public int Range;
    [Range(0, 10)]
    public int FireRate;
    [Range(0, 10)]
    public int Damage;



}
