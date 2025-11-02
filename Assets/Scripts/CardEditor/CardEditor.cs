using UnityEngine;
using System;
using TMPro;

public abstract class CardEditorBase : MonoBehaviour
{
    public TMP_Text Label;
    public string Title;



    public abstract object GetValue();
    public abstract void SetValue(object value);

    public void OnValidate()
    {
        if (Label != null)
        {
            Label = GetComponentInChildren<TMP_Text>();
        }

        if (Label != null)
            Label.text = Title + ":";
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

