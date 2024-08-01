using System.Text;
using UnityEngine;

public class MaterialItem : Item {
    [SerializeField] public MaterialType Type { get; private set; } = MaterialType.JUNK;

    public override string GetDisplayText()
    {
        StringBuilder builder = new();

        builder.Append(Name).AppendLine();
        builder.Append(Description).AppendLine();
        builder.Append(SellPrice).AppendLine();
        builder.Append(MaxStack).AppendLine();

        return builder.ToString();
    }
}

public enum MaterialType {
    JUNK,
    QUEST
}
