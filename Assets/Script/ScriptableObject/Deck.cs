using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Deck : ScriptableObject
{
    public string deckTitle;
    public Card[] cards;
}
