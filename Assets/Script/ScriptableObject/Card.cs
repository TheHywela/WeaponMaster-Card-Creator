using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WEAPON_TYPE
{
    GENERIC,
    SWORDBUCKLER,
    LONGSWORD,
    HALBERD,
    SABRE
}

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public string id;
    public WEAPON_TYPE weaponType;
    public Action topAction;
    public Action bottomAction;
}
