using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int attackDamage;
    public Collider2D attackCollider;

    public void Start() {
        attackDamage = this.gameObject.transform.GetComponentInParent<MemberController>().equipped.weapon.Damage;
    }

    public void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("OnCollisionEnter2d");
        col.collider.SendMessage("OnHit", attackDamage);
    }
}
