using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Scripts.Systems.Party;

public class PlayerCharacter : ICharacter 
{
    public List<Effect> StatEffectsList { get; private set; }
    public List<Effect> TimedEffectsList { get; private set; }
    public List<Effect> PermenantEffectsList { get; private set; }
    private CharacterStats Stats;
    private CharacterEquipped Equipped;

    public PlayerCharacter() {
        Stats = new PlayerCharacterStats(1, 1, 1, 1, 100, 100, 100, 1000, 100, 10f);
        WeaponItem tempWeapon = new WeaponItem();
        Equipped = new CharacterEquipped(tempWeapon);
    }

    public PlayerCharacterStats GetPlayerStats() {
        CalculateEffectiveStats();
        return Stats;
    }

    // General Stats
    public void ChangeStrength(int value) {
        Stats.strength += value;
    }

    public int GetStrength() {
        return Stats.strength;
    }

    public void ChangeAgility(int value) {
        Stats.agility += value;
    }

    public int GetAgility() {
        return Stats.agility;
    }

    public void ChangeIntellect(int value) {
        Stats.intellect += value;
    }

    public int GetIntellect() {
        return Stats.intellect;
    }

    public void ChangeEndurance(int value) {
        Stats.endurance += value;
    }

    public int GetEndurance() {
        return Stats.endurance;
    }

    // Party stats
    public void ChangeSatiation(int value) {
        Stats.satiation += value;
        // Attribute handling??
        switch(Stats.satiation) {
            case 0:
                ChangeHappiness(-10); 
                // also add damage to hp on update within overworld controller
                break;            
            case < 25:
                ChangeHappiness(1);
                break;
        }
    }

    public void ChangeHappiness(int value) {
        Stats.happiness += value;
        // interact with negative satisfaction, potential abandon party at next settlement
    }

    public void ChangeStamina(int value) {
        Stats.stamina += value;
    }

    // Combat Stats
    public bool ChangeHealth(int value) {
        Stats.health += value;

        if(Stats.health <= 0) {
            return true;
        } else {
            return false;
        }
    }

    public bool ChangeMana(int value) {
        int potentialMana = Stats.mana + value;
    
        if(potentialMana < 0) {
            return false;
        } else {
            Stats.mana = potentialMana;
            return true;
        }
    }

    public void ChangeSpeed(float value) {
        Stats.speed += value;
    }

    // Else
    public void ChangeEquipped(WeaponItem weapon = null, ArmourItem armour = null) {
        if(weapon != null) {
            Equipped.weapon = weapon;
        } else {
            switch(armour.slot) {
                case ArmourItem.ItemSlot.HEAD:
                    Equipped.head = armour;
                    break;
                case ArmourItem.ItemSlot.TORSO:
                    Equipped.torso = armour;
                    break;
                case ArmourItem.ItemSlot.HANDS:
                    Equipped.hands = armour;
                    break;
                case ArmourItem.ItemSlot.LEGS:
                    Equipped.legs = armour;
                    break;
                case ArmourItem.ItemSlot.FEET:
                    Equipped.feet = armour;
                    break;
                default:
                    Debug.Log("Equipment is not armour or weapon type");
                    break;
            }
        }
    }

    public WeaponItem GetWeapon() {
        return Equipped.weapon;
    }

    public 

    public void GiveEffect(Effect effect) {
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
            CalculateEffectiveStats(); // recalculate on effects diminishing, potentially have variables inputted to enable lower O
        }
    }

    private void CalculateEffectiveStats() {
        foreach(Effect effect in StatEffectsList) {
            switch(effect.Target) {
                case "strength":
                    ChangeStrength(effect.Strength ?? 0);
                    break;
                case "agility":
                    ChangeAgility(effect.Strength ?? 0);
                    break;
                    // Surely there is a better way of handling this...
            }
        }
    }
}
