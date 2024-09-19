public interface ICharacter 
{
    public CharacterStats GetStats();
    public WeaponItem GetWeapon();
    public bool ChangeHealth(int value);
    public void GiveEffect(Effect effect);     
}
