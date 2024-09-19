using UnityEngine;

namespace Scripts.Systems.ItemSystem;

public class ItemRarity : ScriptableObject {
    [SerializeField] public ItemRarityEnum Rarity { get; private set; } = ItemRarityEnum.COMMON;
    
    public string GetItemColour() {
        return Rarity switch
        {
            ItemRarityEnum.UNCOMMON => "#00ff00",
            ItemRarityEnum.RARE => "#0000ff",
            ItemRarityEnum.EPIC => "#6600ff",
            ItemRarityEnum.LEGENDARY => "#ffcc00",
            _ => "#ffffff",
        };
    }
}

public enum ItemRarityEnum {
    COMMON,
    UNCOMMON,
    RARE,
    EPIC,
    LEGENDARY
}
