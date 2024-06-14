using UnityEngine;

public class ItemRarity : ScriptableObject {
    [SerializeField] public ItemRarityEnum rarity { get; private set; } = ItemRarityEnum.COMMON;
    
    public string GetItemColour() {
        switch(rarity) {
            case ItemRarityEnum.UNCOMMON:
                return "#00ff00";
            case ItemRarityEnum.RARE:
                return "#0000ff";
            case ItemRarityEnum.EPIC:
                return "#6600ff";
            case ItemRarityEnum.LEGENDARY:
                return "#ffcc00";
            default:
                return "#ffffff";
        }
    }
}

public enum ItemRarityEnum {
    COMMON,
    UNCOMMON,
    RARE,
    EPIC,
    LEGENDARY
}
