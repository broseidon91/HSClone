using Newtonsoft.Json;
using UnityEngine;

public class Board : IEventSource
{

    private BoardEventDispatcher eventDispatcher;
    public BoardBehavior behavior;

    public Board()
    {
        eventDispatcher = new BoardEventDispatcher();

        CardContainerObject cards = JsonConvert.DeserializeObject<CardContainerObject>(Resources.Load<TextAsset>("cards").text);

        foreach (var card in cards.cards)
        {
            var newCard = new CardBase(card);
            Player.local.AddCardToDeck(newCard);
        }

        // Player.local.AddCardToDeck(cards.cards);

        eventDispatcher.AddListener(BoardEvents.OnCardDraw, OnDraw);

        CreatePrefab();
    }

   

    public void CreatePrefab()
    {
        var go = GameObject.Instantiate(Resources.Load("Board") as GameObject);
        behavior = go.GetComponent<BoardBehavior>();
        behavior.Init(this);


        LocalPlayerDraw(5);
    }


    public void LocalPlayerDraw(int count = 1)
    {
        eventDispatcher.Dispatch(BoardEvents.OnCardDraw, new EventData(Player.local, Player.local.Draw(count)));
    }

    public void OnDraw(EventData data)
    {
        Player player =  (data.sources[EventDataIndices.PLAYER] as Player);
        if (player.id == Player.local.id)
        {

        }
        else
        {
            //it was the other player
        }
        Debug.LogFormat("Player {0} drew {1} cards", player.id, (data.sources[EventDataIndices.CARD] as CardDraw).cards.Length);
    }
}