using System.Text;

[System.Serializable]
public class ArmourItem : Item {
    private int defense;
    private Effect effect = null;
    public int Defense => defense;
    public Effect Effect => effect;

    public override string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(Name).AppendLine();
        builder.Append(Defense).AppendLine();
        if(Effect != null) 
            builder.Append(Effect).AppendLine();
        builder.Append(Type).AppendLine();
        builder.Append(Description).AppendLine();
        builder.Append(SellPrice).AppendLine();

        return builder.ToString();
    }
}

