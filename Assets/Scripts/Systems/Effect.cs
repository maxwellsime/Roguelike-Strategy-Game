using UnityEngine;
using System.Text;

[System.Serializable]
public class Effect : ScriptableObject {
    public int Id { get; private set; }
    public EffectType Type { get; private set; } = EffectType.STAT;
    public int Rank { get; private set; } = 1;
    public Sprite Icon { get; private set; } = null;
    public string Description { get; private set; } = "";
    public float Duration { get; private set; } = 1;
    public int? Strength { get; private set; } = null;
    public string Target { get; private set; }
    private new string name = "New Effect";

    public string Name => Name;

    // Save event as field then add as function? Potenitally makes type redundant

    public string GetDisplayText() {
        StringBuilder builder = new();

        builder.Append(string.Format("{0} {1}", Name, Rank)).AppendLine();
        builder.Append(Type).AppendLine();
        builder.Append(Description).AppendLine();

        return builder.ToString();
    }
}


public enum EffectType {
    DAMAGE,
    HEAL,
    STAT
}
