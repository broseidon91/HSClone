using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public TMP_Text mana;
    public TMP_Text attack;
    public TMP_Text health;
    public TMP_Text cardName;

    private bool isMouseDown = false;
    public CardData data;
    public CardBase cardBase;

    public void Init(CardData data, CardBase cardBase)
    {
        this.gameObject.name = data.Name;
        this.cardBase = cardBase;
        this.data = data;

        data.OnPropertyChanged += Render;

    }

    public void Render(string field)
    {
        this.gameObject.name = data.Name;

        mana.text = data.Mana.ToString();
        attack.text = data.Attack.ToString();
        health.text = data.Health.ToString();

        cardName.text = data.Name;
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
