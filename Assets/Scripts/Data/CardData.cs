using System;
using Newtonsoft.Json;

[Serializable]
public class CardContainerObject
{
    public CardData[] cards;
}

[Serializable]
public class CardData
{
    public event Action<string> OnPropertyChanged = (value) => { };

    private string _name = "None";
    [JsonProperty("name")]
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged.Invoke(nameof(Name));
            }
        }
    }

    private string _cardText = "";
    [JsonProperty("cardText")]
    public string CardText
    {
        get => _cardText;
        set
        {
            if (_cardText != value)
            {
                _cardText = value;
                OnPropertyChanged.Invoke(nameof(CardText));
            }
        }
    }


    private string _id = "000000";
    [JsonProperty("id")]
    public string Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged.Invoke(nameof(Id));
            }
        }
    }


    private int _mana = 0;
    [JsonProperty("mana")]
    public int Mana
    {
        get => _mana;
        set
        {
            if (_mana != value)
            {
                _mana = value;
                OnPropertyChanged.Invoke(nameof(Mana));
            }
        }
    }


    private int _attack = 0;
    [JsonProperty("attack")]
    public int Attack
    {
        get => _attack;
        set
        {
            if (_attack != value)
            {
                _attack = value;
                OnPropertyChanged.Invoke(nameof(Attack));
            }
        }
    }


    private int _health = 0;
    [JsonProperty("Health")]
    public int Health
    {
        get => _health;
        set
        {
            if (_health != value)
            {
                _health = value;
                OnPropertyChanged.Invoke(nameof(Health));
            }
        }
    }

    private CardRarity _rarity;
    [JsonProperty("rarity")]
    public CardRarity Rarity
    {
        get => _rarity;
        set
        {
            if (_rarity != value)
            {
                _rarity = value;
                OnPropertyChanged.Invoke(nameof(Rarity));
            }
        }
    }

    private CardTribe _tribe;
    [JsonProperty("tribe")]
    public CardTribe Tribe
    {
        get => _tribe;
        set
        {
            if (_tribe != value)
            {
                _tribe = value;
                OnPropertyChanged.Invoke(nameof(Tribe));
            }
        }
    }

    private CardClass _class;
    [JsonProperty("class")]
    public CardClass Class
    {
        get => _class;
        set
        {
            if (_class != value)
            {
                _class = value;
                OnPropertyChanged.Invoke(nameof(Class));
            }
        }
    }



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


