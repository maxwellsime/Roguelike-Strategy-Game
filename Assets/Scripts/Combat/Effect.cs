using UnityEngine;
using System.Text;

public class Effect : ScriptableObject {
    [SerializeField] public int Id { get; private set; }
    [SerializeField] public EffectType Type { get; private set; } = EffectType.STAT;
    [SerializeField] public int Rank { get; private set; } = 1;
    [SerializeField] public Sprite Icon { get; private set; } = null;
    [SerializeField] public string Description { get; private set; } = "";
    [SerializeField] public float Duration { get; private set; } = 1;
    [SerializeField] private new string name = "New Effect";

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

