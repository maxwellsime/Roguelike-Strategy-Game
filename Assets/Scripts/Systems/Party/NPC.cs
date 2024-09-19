using UnityEngine;
using System.Collections.Generic;

public class Npc : ICharacter
{
    public List<Effect> StatEffectsList { get; private set; }
    public List<Effect> TimedEffectsList { get; private set; }
    public List<Effect> PermenantEffectsList { get; private set; }
    private CharacterStats Stats;
    private CharacterEquipped Equipped;

    public Npc()
    {
        Stats = new CharacterStats(1, 1, 1, 1, 100, 100, 100, 1000, 100, 10f);
        WeaponItem tempWeapon = new WeaponItem();
        Equipped = new CharacterEquipped(tempWeapon);
    }

    private void FixedUpdate()
    {
        if (TimedEffectsList.Count > 0)
        {
            // Time effect based on duration remove when it reaches counter, potentially array, maybe dictionary is too big, parallel lists??? test O
            CalculateEffectiveStats(); // recalculate on effects diminishing, potentially have variables inputted to enable lower O
        }
    }

    public CharacterStats GetStats()
    {
        CalculateEffectiveStats();
        return Stats;
    }
    
    public WeaponItem GetWeapon()
    {
        return Equipped.weapon;
    }

    // Combat Stats
    public bool ChangeHealth(int value)
    {
        Stats.health += value;

        if (Stats.health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GiveEffect(Effect effect)
    {
        if (effect.Type == EffectType.STAT)
        {
            StatEffectsList.Add(effect);
        }

        if (effect.Duration > 0)
        {
            TimedEffectsList.Add(effect);
        }
        else
        {
            PermenantEffectsList.Add(effect);
        }
    }

    private void CalculateEffectiveStats()
    {
        /*foreach (Effect effect in StatEffectsList)
        {
            switch (effect.Target)
            {
                case "strength":
                    ChangeStrength(effect.Strength ?? 0);
                    break;
                case "agility":
                    ChangeAgility(effect.Strength ?? 0);
                    break;
                    // Surely there is a better way of handling this...
            }
        }*/
    }
}