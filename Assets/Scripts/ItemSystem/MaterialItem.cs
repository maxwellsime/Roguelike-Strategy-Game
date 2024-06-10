using System.Text;

[System.Serializable]
public class MaterialItem : Item {
    public override string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(Name).AppendLine();
        builder.Append(Type).AppendLine();
        builder.Append(Description).AppendLine();
        builder.Append(SellPrice).AppendLine();
        builder.Append(MaxStack).AppendLine();

        return builder.ToString();
    }
}

