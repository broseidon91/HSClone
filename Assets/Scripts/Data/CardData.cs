using System;

[Serializable]
public class CardContainerObject 
{
    public CardData[] cards;
}

[Serializable]
public class CardData 
{
    public string name = "None";
    public string id = "000000";
    public int mana = 0;
    public int attack = 0;
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


