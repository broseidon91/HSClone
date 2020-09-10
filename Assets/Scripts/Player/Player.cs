using System;
using System.Collections.Generic;

public class Player : IEventSource
{
    public Guid id;

    public static Player local;

    public Stack<CardBase> deck = new Stack<CardBase>();
    public Stack<CardBase> hand = new Stack<CardBase>();

    public Player()
    {
        id = Guid.NewGuid();
        local = this;
    }

    public void AddToDeck(List<CardData> cards)
    {
        foreach (var card in cards)
        {
            var newCard = new CardBase(card);
            deck.Push(newCard);
        }
    }

    public CardBase Draw()
    {
        hand.Push(deck.Pop());
        hand.Peek().OnDraw();
        return hand.Peek();
    }
}