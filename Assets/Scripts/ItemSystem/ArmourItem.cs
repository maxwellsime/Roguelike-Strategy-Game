using System.Text;

public class ArmourItem : Item {
    private int defense;
    private string effect = null;   // Potentially new type when decided upon at a later date.
    public int Defense => defense;
    public string Effect => effect;

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

