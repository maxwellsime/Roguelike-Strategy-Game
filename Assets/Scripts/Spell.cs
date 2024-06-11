using System.Collections.Generic;
using UnityEngine;
using System.Text;

[System.Serializable]
public class Spell : ScriptableObject {
    private int id;

    [Header("Spell Data")]
    [SerializeField] private new string name = "New Spell";
    [SerializeField] private List<Effect> effects;
    [SerializeField] private int rank = 1;
    [SerializeField] private Sprite icon = null;
    [SerializeField] private Sprite visual = null;
    [SerializeField] private string description = "";

    public int Id => id;
    public string Name => name;
    public List<Effect> Effects => effects;
    public int Rank => rank;
    public string Description => description;
}

// Open to potentially many more during game design phase
public enum EffectType {
    DAMAGE,
    HEAL,
    STAT
}

[System.Serializable]
public class Effect : ScriptableObject {
    private int id;

    [Header("Effect Data")]
    [SerializeField] private new string name = "New Effect";
    [SerializeField] private EffectType type = EffectType.STAT;
    [SerializeField] private int rank = 1;
    [SerializeField] private Sprite icon = null;
    [SerializeField] private string description = "";
    [SerializeField] private float duration = 1;

    public int Id => id;
    public string Name => name;
    public EffectType Type => type;
    public int Rank => rank;
    public string Description => description;
    public float Duration => duration;

    public string GetDisplayText() {
        StringBuilder builder = new StringBuilder();

        builder.Append(string.Format("{0} {1}", Name, Rank)).AppendLine();
        builder.Append(Type).AppendLine();
        builder.Append(Description).AppendLine();

        return builder.ToString();
    }
}
