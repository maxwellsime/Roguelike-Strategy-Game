using System.Text;
using UnityEngine;

public class WeaponItem : Item {
    [SerializeField] public int damage { get; private set; } = 1;
    [SerializeField] public int range { get; private set; } = 0;
    [SerializeField] public Effect effect { get; private set; } = null;
    [SerializeField] public new int maxStack { get; private set; } = 1;
    
    public override string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(name).AppendLine();
        builder.Append(description).AppendLine();
        builder.Append(sellPrice).AppendLine();

        return builder.ToString();
    }
}

