using UnityEngine;

public enum ItemType {
    EQUIPPABLE,
    CONSUMABLE,
    MATERIAL
}

public enum ItemRarity : int {
    COMMON,
    UNCOMMON,
    RARE,
    EPIC,
    LEGENDARY
}

public abstract class Item : ScriptableObject {
    private int id; // Maybe this will be useful?

    [Header("Item Data")]
    [SerializeField] private new string name = "New Item";
    [SerializeField] private ItemType type = ItemType.MATERIAL;
    [SerializeField] private ItemRarity rarity = ItemRarity.COMMON;
    [SerializeField] private Sprite icon = null;
    [SerializeField] private string description = "";
    [Min(0)] private int sellPrice = 1;
    [Min(0)] private int maxStack = 1;

    public string Name => name;
    public ItemType Type => type;
    public ItemRarity Rarity => rarity;
    public string Description => description;
    public int SellPrice => sellPrice;
    public int MaxStack => maxStack;

    public abstract string GetDisplayText();
}
