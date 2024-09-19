public interface ICharacter 
{
    public CharacterStats GetStats();
    public WeaponItem GetWeapon();
    public bool ChangeHealth();
    public void GiveEffect();     
    private CharacterStats CalculateStats();
}
