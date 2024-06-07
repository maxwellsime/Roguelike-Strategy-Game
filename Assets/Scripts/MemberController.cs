using UnityEngine;
using UnityEngine.UIElements;

public class MemberController : MonoBehaviour
{   
    private Vector2 desiredPosition;
    private float speed = 10f;
    public int damage = 1;
    public int range = 0;
    public Status memberStatus;
    public IWeapon weapon;
    public GameObject attackHitBox;


    private void Start() {
        desiredPosition = transform.position;
        weapon = new MeleeWeapon(damage, range);
        memberStatus = Status.NEUTRAL;
        attackHitBox = this.gameObject.transform.Find("AttackHitBox").gameObject;
    }

    private void Update() {
        this.transform.position = Vector2.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);
    }

    public void Move(Vector2 inputPosition) {
        if(memberStatus != Status.IMMOBILIZED) {
            memberStatus = Status.MOVING;
            desiredPosition = inputPosition;
            EnableAttacking(false);
        } else {
            Debug.Log("Party member cannot move when immobilized.");
        }
    }

    public void Attack(Vector2 inputPosition) {
        Debug.Log("Attack!");
        desiredPosition = this.transform.position;
        memberStatus = Status.ATTACKING;
        
        Vector2 attackVector;
        if(weapon.range == 0) {
            attackVector = (Vector2)this.transform.position + inputPosition.normalized;
        } else {
            attackVector = inputPosition;
            // Make based on ranged input that needs to be normalized based on resolution??
        }
        
        attackHitBox.transform.position = attackVector;
        EnableAttacking(true);
    }

    public void EnableAttacking(bool enable) {
        attackHitBox.SetActive(enable);
    }

    public enum Status {
        MOVING,
        CHANNELING,
        NEUTRAL,
        ATTACKING,
        IMMOBILIZED
    }
}

// Temporary location for class before understanding the appropriate method of implementation.
public abstract class IWeapon {
    public int range;
    public int weaponID;
    public int damage;
}

public class MeleeWeapon : IWeapon {
    public MeleeWeapon(int damage, int range) {
        this.damage = damage;
        this.range = range;
    }
}
