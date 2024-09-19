[System.Serializable]
public struct Party
{
    public PlayerCharacter[] partyMembers;
    public Inventory inventory;
    public float speed;

    public Party(
        PlayerCharacter character1 = null,
        PlayerCharacter character2 = null,
        PlayerCharacter character3 = null,
        PlayerCharacter character4 = null,
        Inventory inventory = null,
        float speed = 10f
    )
    {
        this.partyMembers = new PlayerCharacter[4];
        this.partyMembers[0] = character1;
        this.partyMembers[1] = character2;
        this.partyMembers[2] = character3;
        this.partyMembers[3] = character4;
        this.inventory = inventory;
        this.speed = speed;
    }
}
