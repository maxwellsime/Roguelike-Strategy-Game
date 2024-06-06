using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int attackDamage;
    public Collider2D attackCollider;

    public void Start() {
        attackDamage = this.gameObject.transform.GetComponentInParent<MemberController>().damage;
    }

    public void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("OnCollisionEnter2d");
        col.collider.SendMessage("OnHit", attackDamage);
    }
}
