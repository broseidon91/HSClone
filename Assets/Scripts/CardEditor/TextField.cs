using TMPro;

public class TextField : CardEditorBase
{
    public TMP_InputField Input;

    private string _value = string.Empty;

    public void Awake()
    {

    }

  public override object GetValue() => _value;
    
    public override void SetValue(object value)
    {
        if (value is string str)
            _value = str;
    }
    
    
}