using System;
using UnityEngine;

public class CardBase : IEventSource
{
    private CardEventDispatcher events;
    public CardData data { get; protected set;}
    public CardBehavior behavior;

    public Guid guid;

    public CardBase(CardData data)
    {
        this.data = data;
        events = new CardEventDispatcher();
        guid = Guid.NewGuid();

        CreatePrefab();
    }

    public void CreatePrefab()
    {
        var go = GameObject.Instantiate(Resources.Load("Card") as GameObject);
        behavior = go.GetComponent<CardBehavior>();
        behavior.Init(data, this);
    }

    public void AddListener(string name, Action action)
    {
        events.AddListener(name, action);
    }

    public void RemoveListener(string name, Action action)
    {
        events.RemoveListener(name, action);
    }

    public virtual void OnClick()
    {
        events.Dispatch(CardEvents.OnClick);
    }

    public virtual void OnPlay()
    {
        events.Dispatch(CardEvents.OnPlay);
    }

    public virtual void OnSummon()
    {
        events.Dispatch(CardEvents.OnSummon);
    }

    public virtual void OnBattlecry()
    {
        events.Dispatch(CardEvents.OnBattlecry);
    }

    public virtual void OnTakeDamage()
    {
        events.Dispatch(CardEvents.OnTakeDamage);
    }

    public virtual void OnDealDamage()
    {
        events.Dispatch(CardEvents.OnDealDamage);
    }

    public virtual void OnDeath()
    {
        events.Dispatch(CardEvents.OnDeath);
    }

    public virtual void OnDraw()
    {
        events.Dispatch(CardEvents.OnDraw);
    }

    public virtual void OnShuffle()
    {
        events.Dispatch(CardEvents.OnShuffle);
    }

    public virtual void OnAttack()
    {
        events.Dispatch(CardEvents.OnAttack);
    }
}