

using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardEventDispatcher
{
    public Dictionary<string, BoardEvent> events = new Dictionary<string, BoardEvent>();

    public void AddListener(string name, Action<EventData> action)
    {
        if (events.ContainsKey(name))
        {
            events[name].action += action;
        }
        else
        {
            events[name] = new BoardEvent(action);
        }
    }

    public void RemoveListener(string name, Action<EventData> action)
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

    public void Dispatch(string name, EventData data)
    {
        if (events.ContainsKey(name))
        {
            if (events[name].action != null)
            {
                events[name].action(data);
            }
            else
                Debug.LogErrorFormat("Could not dispatch event {0}", name);

        }

    }
}

public class BoardEvent
{
    public Action<EventData> action;

    public BoardEvent(Action<EventData> action)
    {
        this.action = action;
    }
}

public class EventData
{   
    public List<IEventSource> sources;

    public EventData(params IEventSource[] args)
    {
        sources = new List<IEventSource>(args);
    }
}

public static class EventDataIndices
{
    public const int FROM = 0;
    public const int TO = 1;
    public const int PLAYER = 0;
    public const int CARD = 1;
}

public static class BoardEvents
{
    //PLAYER, CARD
    public const string OnTurnBegin = "OnPlayerTurnBegin";
    public const string OnTurnEnd = "OnPlayerTurnEnd";
    public const string OnHeroPower = "OnHeroPower";
    public const string OnCardPlay = "OnPlay";
    public const string OnCardClick = "OnClick";
    public const string OnCardSummon = "OnSummon";
    public const string OnCardBattlecry = "OnBattlecry";
    public const string OnCardTakeDamage = "OnTakeDamage";
    public const string OnCardDealDamage = "OnDealDamage";
    public const string OnCardDeath = "OnDeath";
    public const string OnCardDraw = "OnDraw";
    public const string OnCardShuffle = "OnShuffle";
    public const string OnCardAttack = "OnAttack";


}