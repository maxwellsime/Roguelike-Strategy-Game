using System;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject {
    [SerializeField] public int Id { get; private set; }
    [SerializeField] public List<Effect> Effects { get; private set; }
    [SerializeField] public int Rank { get; private set; } = 1;
    [SerializeField] public Sprite Icon { get; private set; } = null;
    [SerializeField] public Sprite Visual { get; private set; } = null;
    [SerializeField] public string Description { get; private set; } = "";
    [SerializeField] private new string name = "New Spell";

    public string Name => name;
}
