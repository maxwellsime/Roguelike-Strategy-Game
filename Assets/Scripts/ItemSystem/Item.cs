using UnityEngine;

public abstract class Item : ScriptableObject {
    [SerializeField] public int id { get; private set; }
    [SerializeField] public new string name { get; private set; } = "New Item";
    [SerializeField] public ItemRarity rarity { get; private set; }
    [SerializeField] public Sprite icon { get; private set; } = null;
    [SerializeField] public string description { get; private set; } = "";
    [SerializeField] public int sellPrice { get; private set; } = 1;
    [SerializeField] public int maxStack { get; private set; } = 1;

    public abstract string GetDisplayText();
}
