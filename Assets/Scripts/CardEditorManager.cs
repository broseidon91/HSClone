using UnityEngine;
using Newtonsoft.Json;

public class CardEditorManager : MonoBehaviour
{
    public CardBehavior Card;

    public void Awake()
    {
        CardContainerObject cards = JsonConvert.DeserializeObject<CardContainerObject>(Resources.Load<TextAsset>("cards").text);
        var newCard = new CardBase(cards.cards[0]);
        Card = newCard.behavior;

        Card.transform.SetParent(transform);
        Card.transform.localPosition = new Vector3(0, 0, 2);
        Card.transform.Rotate(new Vector3(-90, 0, 0));

        var fields = FindObjectsByType<CardEditorBase>(FindObjectsSortMode.None);

        foreach (var field in fields)
        {
            field.Setup(newCard.data);
        }

    }

}
