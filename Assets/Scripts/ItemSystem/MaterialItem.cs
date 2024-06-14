using System.Text;
using UnityEngine;

public class MaterialItem : Item {
    [SerializeField] public MaterialType type { get; private set; } = MaterialType.JUNK;

    public override string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(name).AppendLine();
        builder.Append(description).AppendLine();
        builder.Append(sellPrice).AppendLine();
        builder.Append(maxStack).AppendLine();

        return builder.ToString();
    }
}

public enum MaterialType {
    JUNK,
    QUEST
}
