[System.Serializable]
public struct CharacterStats 
{
    public WeaponItem weapon;
    public ArmourItem head;
    public ArmourItem torso;
    public ArmourItem hands;
    public ArmourItem legs;
    public ArmourItem feet;

    public CharacterStats(
        WeaponItem weapon = null,
        ArmourItem head = null,
        ArmourItem torso = null,
        ArmourItem hands = null,
        ArmourItem legs = null,
        ArmourItem feet = null
    ) {
        this.weapon = weapon;
        this.head = head;
        this.torso = torso;
        this.hands = hands;
        this.legs = legs;
        this.feet = feet;
    }
}
