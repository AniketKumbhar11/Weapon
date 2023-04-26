using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "Profile", menuName = "ScriptableObjects/CreateProfile")]
public class ProfileCreate : ScriptableObject
{
    public string ProfileName;
    public Sprite ProfileImage;
    public int Coin;
    public int Money;



}
