using System;
using System.Text;

public class WeaponItem : Item {
    private int damage = 1;
    private int range = 0;
    private string effect = null;       // make effect class
    public int Damage => damage;
    public int Range => range;
    public string Effect => effect;

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

