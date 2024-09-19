using UnityEngine;

namespace Scripts.Systems.ItemSystem;

public abstract class Item : ScriptableObject {
    [SerializeField] public int Id { get; private set; }
    [SerializeField] public ItemRarity Rarity { get; private set; }
    [SerializeField] public Sprite Icon { get; private set; } = null;
    [SerializeField] public string Description { get; private set; } = "";
    [SerializeField] public int SellPrice { get; private set; } = 1;
    [SerializeField] public int MaxStack { get; private set; } = 1;
    [SerializeField] private new string name = "New Item";

    public string Name => name;

    public abstract string GetDisplayText();
}
