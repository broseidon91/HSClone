public class FatigueCard : CardBase
{
    
    public FatigueCard(CardData data = null) : base (data)
    {
        this.data = new CardData();
        
        this.behavior.Init(this.data, this);
    }
}