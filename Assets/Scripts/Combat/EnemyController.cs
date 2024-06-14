using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int _health = 10;

    public int Health {
        set {
            _health = value;

            if(_health <= 0) {
                Destroy(this.gameObject);
            }
        }
        get {
            return _health;
        }
    }

    public void OnHit(int damage) {
        Debug.Log("Hit for " + damage);
        Health -= damage;
    }
}
