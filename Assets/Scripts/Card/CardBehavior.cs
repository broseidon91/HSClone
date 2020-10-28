using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public TextMeshPro mana;
    public TextMeshPro attack;
    public TextMeshPro health;
    public TextMeshPro cardName;

    private bool isMouseDown = false;
    public CardData data;
    public CardBase cardBase;
    public void Init(CardData data, CardBase cardBase)
    {
        this.gameObject.name = data.name;
        this.cardBase = cardBase;
        this.data = data;

        mana.text = data.mana.ToString();
        attack.text = data.attack.ToString();
        health.text = data.health.ToString();

        cardName.text = data.name;

    }

    public void OnMouseDown()
    {
        isMouseDown = true;
    }

    public void OnMouseUp()
    {
        isMouseDown = false;
    }

   

    public void Update()
    {

    }

}
