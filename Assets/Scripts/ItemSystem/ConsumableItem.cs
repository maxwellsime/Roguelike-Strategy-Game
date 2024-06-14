using System.Text;
using UnityEngine;

public class ConsumableItem : Item {

    [SerializeField] public Effect Effect { get; private set; } = null;

    public override string GetDisplayText()
    {
        StringBuilder builder = new();

        builder.Append(Name).AppendLine();
        builder.Append(Description).AppendLine();
        builder.Append(Effect).AppendLine();
        builder.Append(SellPrice).AppendLine();
        builder.Append(MaxStack).AppendLine();

        return builder.ToString();
    }
}
