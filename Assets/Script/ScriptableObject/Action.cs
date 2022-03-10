using UnityEngine;

public enum ACTION_TYPE
{
    ACTION,
    MOVE,
    ATTACK,
    PARRY
}


[CreateAssetMenu]
public class Action : ScriptableObject
{
    public string id;
    public ACTION_TYPE actionType;
    public string title;
    public string cost;
    public string speed;
    [TextArea(15, 20)]
    public string description;
    public Sprite referenceImage;
}
