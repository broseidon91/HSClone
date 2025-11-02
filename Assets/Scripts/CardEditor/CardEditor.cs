using UnityEngine;
using System;
using TMPro;

public abstract class CardEditorBase : MonoBehaviour
{

    public TMP_Text Label;
    public string Title;

    public CardFieldEnum Field;
    public CardData Card;

    public virtual void Setup(CardData cardData)
    {
        this.Card = cardData;
    }


    public void OnValidate()
    {
        if (Label != null)
        {
            Label = GetComponentInChildren<TMP_Text>();
        }

        if (Label != null)
            Label.text = Title + ":";
    }

    public virtual void SetValue(object value)
    {
        switch (Field)
        {
            case CardFieldEnum.Name:
                Card.Name = (string)value;
                break;
            case CardFieldEnum.Health:
                Card.Health = (int)value;
                break;
            case CardFieldEnum.Attack:
                Card.Attack = (int)value;
                break;
            case CardFieldEnum.Rarity:
                Card.Rarity = (CardRarity)value;
                break;
            case CardFieldEnum.Tribe:
                Card.Tribe = (CardTribe)value;
                break;
            case CardFieldEnum.CardText:
                Card.CardText = (string)value;
                break;
            case CardFieldEnum.Class:
                Card.Class = (CardClass)value;
                break;
        }
    }

    public virtual object GetValue()
    {
        switch (Field)
        {
            case CardFieldEnum.Name:
                return Card.Name;
            case CardFieldEnum.Health:
                return Card.Health;
            case CardFieldEnum.Attack:
                return Card.Attack;
            case CardFieldEnum.Rarity:
                return Card.Rarity;
            case CardFieldEnum.Tribe:
                return Card.Tribe;
            case CardFieldEnum.CardText:
                return Card.CardText;
            case CardFieldEnum.Class:
                return Card.Class;
            default:
                return "";
        }
    }
}

[Serializable]
public enum CardFieldEnum
{
    Name,
    Health,
    Attack,
    Rarity,
    Tribe,
    CardText,
    Class,
    Portrait,
}

public enum InputType
{
    Number,
    Text,
    Array,
    Enum
}

public enum CardRarity
{

    None,
    Common,
    Rare,
    Epic,
    Legendary
}

public enum CardTribe
{
    Neutral,
    Beast,
    Demon,
    Dragon,
    Elemental,
    Mech,
    Murloc,
    Naga,
    Pirate,
    Quilboar,
    Totem,
    Undead
}

public enum CardClass
{
    DeathKnight,
    DemonHunter,
    Druid,
    Hunter,
    Mage,
    Paladin,
    Priest,
    Rogue,
    Shaman,
    Warlock,
    Warrior,
    Neutral
}

