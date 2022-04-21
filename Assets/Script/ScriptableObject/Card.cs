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
    public bool isStarter;
    public string id;
    public WEAPON_TYPE weaponType;
    public Action topAction;
    public Action bottomAction;
}
