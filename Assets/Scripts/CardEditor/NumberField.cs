using TMPro;
using UnityEngine;

public class NumberField : CardEditorBase
{
    public TMP_InputField Input;


    private int _value = 0;

    public override void Setup(CardData data)
    {
        base.Setup(data);
        Input.text = GetValue().ToString();
        Input.onValidateInput += ValidateChar;
        Input.onValueChanged.AddListener(OnValueChanged);
    }

    // Prevent non-digit characters from being typed
    private char ValidateChar(string text, int charIndex, char addedChar)
    {
        // Allow digits and minus sign at start
        if (char.IsDigit(addedChar) && charIndex < 2)
            return addedChar;

        // if (addedChar == '-' && charIndex == 0)
        //     return addedChar;

        return '\0'; // Reject character
    }

    public void OnValueChanged(string value)
    {
        int outVal = 0;
        if (int.TryParse(value, out outVal))
        {
            SetValue(outVal);
        }
    }

}
