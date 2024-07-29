using System;
using UnityEngine;

[System.Serializable]
public struct MemberStats {
    public int health;
    public int stamina;
    public float speed;
    public int agility;
    public int strength;
    public int intellect;

    public MemberStats(int health, int stamina, float speed, int agility, int strength, int intellect) {
        this.health = health;
        this.stamina = stamina;
        this.speed = speed;
        this.agility = agility;
        this.strength = strength;
        this.intellect = intellect;
    }
}

[System.Serializable]
public struct MemberEquipped {
    public WeaponItem weapon;
    public ArmourItem head;
    public ArmourItem torso;
    public ArmourItem hands;
    public ArmourItem legs;
    public ArmourItem feet;

    public MemberEquipped(WeaponItem weapon = null, ArmourItem head = null, ArmourItem torso = null, ArmourItem hands = null, ArmourItem legs = null, ArmourItem feet = null) {
        this.weapon = weapon;
        this.head = head;
        this.torso = torso;
        this.hands = hands;
        this.legs = legs;
        this.feet = feet;
    }
}

public class MemberController : MonoBehaviour {   
    private Vector2 desiredPosition;
    private float speed = 10f;
    public MemberStats stats;
    public MemberEquipped equipped;
    public Status memberStatus;
    public GameObject attackHitBox;


    private void Start() {
        desiredPosition = transform.position;
        memberStatus = Status.NEUTRAL;
        attackHitBox = this.gameObject.transform.Find("AttackHitBox").gameObject;
        stats = new MemberStats(100, 100, 10f, 0, 0, 0);
        WeaponItem tempWeapon = new WeaponItem();
        equipped = new MemberEquipped(tempWeapon);
    }

    private void Update() {
        this.transform.position = Vector2.MoveTowards(transform.position, desiredPosition, stats.speed * Time.deltaTime);
    }

    public void Move(Vector2 inputPosition, Bounds arenaBounds) {
        if(memberStatus != Status.IMMOBILIZED) {
            Vector2 memberSize  = this.gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds.size;
            Vector2 arenaMaximum = arenaBounds.max;
            Vector2 arenaMinimum = arenaBounds.min;
            Vector2 clampedPosition = new(
                Mathf.Clamp(inputPosition.x, arenaMinimum.x + memberSize.x / 2, arenaMaximum.x - memberSize.x / 2),
                Mathf.Clamp(inputPosition.y, arenaMinimum.y + memberSize.y / 2, arenaMaximum.y - memberSize.y / 2)
            );
            
            memberStatus = Status.MOVING;
            desiredPosition = clampedPosition;
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
        if(equipped.weapon.Range == 0) {
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
        NEUTRAL,
        MOVING,
        CHANNELING,
        ATTACKING,
        IMMOBILIZED
    }
}
