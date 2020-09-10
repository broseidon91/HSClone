using UnityEngine;

public class Board : IEventSource
{

    private BoardEventDispatcher eventDispatcher;
    public BoardBehavior behavior;

    public Board()
    {
        eventDispatcher = new BoardEventDispatcher();

        CardContainerObject cards = JsonUtility.FromJson<CardContainerObject>(Resources.Load<TextAsset>("cards").text);

        // int x = 0;
        // int y = 0;
        // foreach (var card in cards.cards)
        // {
        //     CardBase cardBase = new CardBase(card);

        //     cardBase.behavior.gameObject.transform.position = new Vector3(x * 1.5f, 0, y * 3f);
        //     x++;

        //     if (x >= 5)
        //     {
        //         x = 0;
        //         y++;
        //     }
        // }

        Player.local.AddToDeck(cards.cards);

        eventDispatcher.AddListener(BoardEvents.OnCardDraw, OnDraw);

        CreatePrefab();
    }

    public void CreatePrefab()
    {
        var go = GameObject.Instantiate(Resources.Load("Board") as GameObject);
        behavior = go.GetComponent<BoardBehavior>();
        behavior.Init(this);
    }

    public void Draw()
    {
        eventDispatcher.Dispatch(BoardEvents.OnCardDraw, new EventData(Player.local, Player.local.Draw()));
    }

    public void OnDraw(EventData data)
    {
        Debug.LogFormat("Player {0} drew card {1}", (data.sources[EventDataIndices.PLAYER] as Player).id, (data.sources[EventDataIndices.CARD] as CardBase).data.name);
    }
}