using System.Text;
using UnityEngine;

public class ArmourItem : Item {
    [SerializeField] public int Defense { get; private set; }
    [SerializeField] public Effect Effect { get; private set; } = null;

    public override string GetDisplayText()
    {
        StringBuilder builder = new();

        builder.Append(Name).AppendLine();
        builder.Append(Defense).AppendLine();
        if(Effect != null) 
            builder.Append(Effect).AppendLine();
        builder.Append(Description).AppendLine();
        builder.Append(SellPrice).AppendLine();

        return builder.ToString();
    }
}

