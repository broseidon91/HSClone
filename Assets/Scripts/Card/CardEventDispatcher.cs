
using System;
using System.Collections.Generic;
using UnityEngine;

public class CardEventDispatcher
{
    public Dictionary<string, CardEvent> events = new Dictionary<string, CardEvent>();

    public void AddListener(string name, Action action)
    {
        if (events.ContainsKey(name))
        {
            events[name].action += action;
        }
        else
        {
            events[name] = new CardEvent(action);
        }
    }

    public void RemoveListener(string name, Action action)
    {
        if (events.ContainsKey(name))
        {
            events[name].action -= action;
        }
    }

    public void RemoveKey(string name)
    {
        events.Remove(name);
    }

    public void Dispatch(string name)
    {
        if (events.ContainsKey(name))
        {
            if (events[name].action != null)
            {
                events[name].action();
            }
            else
                Debug.LogErrorFormat("Could not dispatch event {0}", name);

        }
      
    }
}

public class CardEvent
{
    public Action action;
    public CardEvent()
    {
        this.action = () => { };
    }

    public CardEvent(Action action)
    {
        this.action = action;
    }
}

public class CardEvents
{
    public static string OnPlay = "OnPlay";
    public static string OnClick = "OnClick";
    public static string OnSummon = "OnSummon";
    public static string OnBattlecry = "OnBattlecry";
    public static string OnTakeDamage = "OnTakeDamage";
    public static string OnDealDamage = "OnDealDamage";
    public static string OnDeath = "OnDeath";
    public static string OnDraw = "OnDraw";
    public static string OnShuffle = "OnShuffle";
    public static string OnAttack = "OnAttack";
}