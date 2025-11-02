using System;
using System.Linq;
using TMPro;

public class EnumField<T> : CardEditorBase where T : struct, Enum
{
    public TMP_Dropdown Dropdown;


    public override void Setup(CardData cardData)
    {
        base.Setup(cardData);

        Dropdown.value = (int)GetValue();
        Dropdown.onValueChanged.AddListener(OnValueChanged);
    }

    public virtual void OnValueChanged(int val)
    {
        SetValue((T)(object)val);
    }


    public void OnValidate()
    {
        base.OnValidate();

        if (Dropdown != null)
        {
            Dropdown = GetComponentInChildren<TMP_Dropdown>();
        }

        if (Dropdown != null)
        {
            Dropdown.ClearOptions();

            // Get all enum values as strings
            var options = Enum.GetNames(typeof(T)).ToList();

            Dropdown.AddOptions(options);
        }
    }


}