using UnityEngine;

[System.Serializable]
public struct PlayerCharacterStats {
    // General
    [Range(1, 100)] public int agility;
    [Range(1, 100)] public int strength;
    [Range(1, 100)] public int intellect;
    [Range(1, 100)] public int endurance;

    // Party
    [Range(0, 100)] public int happiness;
    [Range(0, 100)] public int satiation;
    [Range(0, 100)] public int stamina;

    // Personality
    // TBD

    // Combat
    public int health;
    public int mana;
    public float speed;

    public PlayerCharacterStats(
        int agility,
        int strength,
        int intellect,
        int endurance,
        int happiness,
        int satiation,
        int stamina,
        int health,
        int mana,
        float speed
    ) {
        this.agility = agility;
        this.strength = strength;
        this.intellect = intellect;
        this.endurance = endurance;
        this.happiness = happiness;
        this.satiation = satiation;
        this.health = health;
        this.mana = mana;
        this.stamina = stamina;
        this.speed = speed;
    }
}
