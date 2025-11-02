using TMPro;

public class NumberField : CardEditorBase
{
    public TMP_InputField Input;

    private int _value = 0;

    public void Awake()
    {

    }

  public override object GetValue() => _value;
    
    public override void SetValue(object value)
    {
        if (value is int str)
            _value = str;
    }
}
