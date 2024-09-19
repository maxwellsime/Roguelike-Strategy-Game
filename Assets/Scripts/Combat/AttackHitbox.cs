using UnityEngine;

public class AttackHitbox : MonoBehaviour {
    public int attackDamage;
    public Collider2D attackCollider;

    public void Start() {
        WeaponItem weapon = this.gameObject.transform.GetComponentInParent<PartyMemberController>().character.GetWeapon();
        attackDamage = weapon.Damage;
    }

    public void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("OnCollisionEnter2d");
        col.collider.SendMessage("OnHit", attackDamage);
    }
}
