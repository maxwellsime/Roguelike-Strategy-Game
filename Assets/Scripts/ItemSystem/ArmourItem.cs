using System.Text;
using UnityEngine;

public class ArmourItem : Item {
    [SerializeField] public int defense { get; private set; }
    [SerializeField] public Effect effect { get; private set; } = null;

    public override string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(name).AppendLine();
        builder.Append(defense).AppendLine();
        if(effect != null) 
            builder.Append(effect).AppendLine();
        builder.Append(description).AppendLine();
        builder.Append(sellPrice).AppendLine();

        return builder.ToString();
    }
}

