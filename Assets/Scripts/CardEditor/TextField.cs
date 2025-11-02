using TMPro;

public class TextField : CardEditorBase
{
    public TMP_InputField Input;

    private string _value = string.Empty;

    public override void Setup(CardData cardData)
    {
        base.Setup(cardData);
        Input.text = GetValue().ToString();
        Input.onValueChanged.AddListener(SetValue);
    }

}