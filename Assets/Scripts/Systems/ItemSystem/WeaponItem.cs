using System.Text;
using UnityEngine;

public class WeaponItem : Item {
    [SerializeField] public int Damage { get; private set; } = 1;
    [SerializeField] public int Range { get; private set; } = 0;
    [SerializeField] public Effect Effect { get; private set; } = null;
    [SerializeField] public new int MaxStack { get; private set; } = 1;
    
    public override string GetDisplayText()
    {
        StringBuilder builder = new();

        builder.Append(Name).AppendLine();
        builder.Append(Description).AppendLine();
        builder.Append(SellPrice).AppendLine();

        return builder.ToString();
    }
}

