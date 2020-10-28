using System;
using System.Collections.Generic;
using UnityEngine;
public class Player : IEventSource, IUpdate
{
    public Guid id;

    public static Player local;


    public List<CardBase> deck = new List<CardBase>();
    public List<CardBase> hand = new List<CardBase>();


    public Player()
    {
        id = Guid.NewGuid();
        local = this;
    }

    public void AddToDeck(CardBase[] cards)
    {
        foreach (var card in cards)
        {
            deck.Add(card);
        }
    }

    public void AddCardToDeck(CardBase card)
    {
        deck.Add(card);
        card.behavior.gameObject.transform.position = new UnityEngine.Vector3(6.5f, 0, -3);
    }

    public CardDraw Draw(int count = 1)
    {
        var drawn = new CardBase[count];
        for (int i = 0; i < count; i++)
        {
            if (deck.Count > 0)
            {
                var card = deck[deck.Count - 1];
                deck.Remove(card);
                hand.Add(card);
                card.OnDraw();
                drawn[i] = card;
            }
            else
            {
                drawn[i] = new FatigueCard();
            }
        }

        var cardDraw = new CardDraw();
        cardDraw.cards = drawn;
        
        PositionHand();
        return cardDraw;
    }

    public void Update()
    {

    }

    public void PositionHand()
    {
        var centerScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 6, 5f));

        float cardWidth = 1f;
        for (int i = 0; i < hand.Count; i++)
        {
            var card = hand[i];
            // card.behavior.gameObject.transform.position = centerScreen + new Vector3(i * cardWidth - (cardWidth * (hand.Count - 1)) / 2 , 0, 0);
            var animEvent = new CardMoveAnimation(card.guid);
            var data = new AnimationEvent.Data();
            data.Add("start", card.behavior.gameObject.transform.position);
            data.Add("end", centerScreen + new Vector3(i * cardWidth - (cardWidth * (hand.Count - 1)) / 2, 0, 0));
            data.Add("behaviour", card.behavior.gameObject);
            data.Add("animationTime", 1f);
            animEvent.OnSetup(data);
            AnimationManager.Instance.AddEvent(animEvent);

        }

        AnimationManager.Instance.QueueNextEvent();
    }
}

public class CardDraw : IEventSource
{
    public CardBase[] cards;
}