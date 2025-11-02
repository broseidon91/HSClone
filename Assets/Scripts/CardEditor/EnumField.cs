using System;
using System.Linq;
using TMPro;

public class EnumField<T> : CardEditorBase where T : struct, Enum
{
    public TMP_Dropdown Dropdown;


    private T _value;
     
    public T Value
    {
        get => _value;
        set => _value = value;
    }

    public override object GetValue() => _value;

    public override void SetValue(object value)
    {
        if (value is T enumValue)
            _value = enumValue;
    }

    public void Awake()
    {
        Dropdown.onValueChanged.AddListener(OnValueChanged);
    }

    public virtual void OnValueChanged(int val)
    {
        SetValue(val);
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