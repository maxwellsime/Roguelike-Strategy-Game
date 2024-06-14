using System.Text;
using UnityEngine;

public class ConsumableItem : Item {

    [SerializeField] public Effect effect { get; private set; } = null;

    public override string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(name).AppendLine();
        builder.Append(description).AppendLine();
        builder.Append(effect).AppendLine();
        builder.Append(sellPrice).AppendLine();
        builder.Append(maxStack).AppendLine();

        return builder.ToString();
    }
}
