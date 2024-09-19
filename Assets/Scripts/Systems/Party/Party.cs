namespace Scripts.Systems.Party;

[System.Serializable]
public struct Party(
    ICharacter character1 = null,
    ICharacter character2 = null,
    ICharacter character3 = null,
    ICharacter character4 = null,
    Inventory inventory = null,
    float speed = 10f
) 
{
    this.partyMembers = new ICharacter[4];
    this.partyMembers[0] = character1;
    this.partyMembers[1] = character2;
    this.partyMembers[2] = character3;
    this.partyMembers[3] = character4;    
    public Inventory inventory = inventory;
    public float speed = speed;
}
