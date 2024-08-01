using UnityEngine.TestTools.Constraints;

public class PlayerCharacter {
    public PlayerCharacterStats stats;
    public PlayerCharacterEquipped equipped;

    public PlayerCharacter() {
        stats = new PlayerCharacterStats(1, 1, 1, 1, 100, 100, 100, 1000, 100, 10f);
        WeaponItem tempWeapon = new WeaponItem();
        equipped = new PlayerCharacterEquipped(tempWeapon);
    }

    public void changeSatiation(int value) {
        stats.satiation += value;
        // Attribute handling??
        switch(stats.satiation) {
            case 0:
                changeHappiness(-10); 
                // also add damage to hp on update within overworld controller
                break;            
            case < 25:
                changeHappiness(1);
                break;
        }
    }

    public void changeHappiness(int value) {
        stats.happiness += value;
        // interact with negative satisfaction, potential abandon party at next settlement
    }

    public void changeGeneralStat(int value, string statName) {
        stats.statName += value;    // make this work
    }
}
