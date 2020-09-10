using System;

[Serializable]
public class CardContainerObject 
{
    public CardData[] cards;
}

[Serializable]
public class CardData 
{
    public string name;
    public string id;
    public int mana;
    public int attack;
    public int health ;
    public string cardType;
    public string[] tags;
    public string[] types;
    public string set;
    public string rarity;
    public string imageUrl;
    public string cardText;
    public string[] keywords;
    public Trigger[] triggers;
}

[Serializable]
public class Trigger
{
    public string trigger;
    public string targets;
    public string targeting;
    public string[] filters;
    public string effect;
    public string[] values;
    public string gfx;
}


