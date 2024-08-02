using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class PlayerCharacter {
    public PlayerCharacterStats Stats { get; private set; }
    public PlayerCharacterEquipped Equipped { get; private set; }
    public List<Effect> StatEffectsList { get; private set; }
    public List<Effect> TimedEffectsList { get; private set; }
    public List<Effect> PermenantEffectsList { get; private set; }

    public PlayerCharacter() {
        Stats = new PlayerCharacterStats(1, 1, 1, 1, 100, 100, 100, 1000, 100, 10f);
        WeaponItem tempWeapon = new WeaponItem();
        Equipped = new PlayerCharacterEquipped(tempWeapon);
    }

    // General Stats
    public void changeStrength(int value) {
        Stats.strength += value;
    }

    public void changeAgility(int value) {
        Stats.agility += value;
    }

    public void changeIntellect(int value) {
        Stats.intellect += value;
    }

    public void changeEndurance(int value) {
        Stats.endurance += value;
    }

    // Party stats
    public void changeSatiation(int value) {
        Stats.satiation += value;
        // Attribute handling??
        switch(Stats.satiation) {
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
        Stats.happiness += value;
        // interact with negative satisfaction, potential abandon party at next settlement
    }

    public void changeStamina(int value) {
        Stats.stamina += value;
    }

    // Combat Stats
    public bool changeHealth(int value) {
        Stats.health += value;

        if(Stats.health <= 0) {
            return true;
        } else {
            return false;
        }
    }

    public bool changeMana(int value) {
        int potentialMana = Stats.mana + value;
    
        if(potentialMana < 0) {
            return false;
        } else {
            Stats.mana = potentialMana;
            return true;
        }
    }

    public void changeSpeed(float value) {
        Stats.agility = Stats.agility + value;
    }

    // Else
    public void changeEquipped(WeaponItem weapon = null, ArmourItem armour = null) {
        if(weapon != null) {
            Equipped.weapon = weapon;
        } else {
            switch(armour.slot) {
                case ItemSlot.HEAD:
                    Equipped.head = armour;
                    break;
                case ItemSlot.TORSO:
                    Equipped.torso = armour;
                    break;
                case ItemSlot.HANDS:
                    Equipped.hands = armour;
                    break;
                case ItemSlot.LEGS:
                    Equipped.legs = armour;
                    break;
                case ItemSlot.FEET:
                    Equipped.feet = armour;
                    break;
                default:
                    Debug.Log("Equipment is not armour or weapon type");
                    break;
            }
        }
    }

    public void giveEffect(Effect effect) {
        if(effect.Type == EffectType.STAT) {
            StatEffectsList.Add(effect);
        }
        
        if(effect.Duration != 0) {
            TimedEffectsList.Add(effect);
        } else {
            PermenantEffectsList.Add(effect);
        }
    }

    private void FixedUpdate() {
        if(TimedEffectsList.Count > 0) {
            // Time effect based on duration remove when it reaches counter, potentially array, maybe dictionary is too big, parallel lists??? test O
        }
    }
}
