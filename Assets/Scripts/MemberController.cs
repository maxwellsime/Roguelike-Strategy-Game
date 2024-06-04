using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MemberController : MonoBehaviour
{   
    private Vector2 desiredPosition;
    private float speed = 10f;
    public static int damage = 1;
    public static int range = 5;
    public Status memberStatus;
    public IWeapon mainhand;
    public GameObject attackHitBox;


    private void Start() {
        desiredPosition = transform.position;
        mainhand = new MeleeWeapon(damage, "Sword", range);
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
        attackHitBox.transform.position = inputPosition; // Have to make relative to member object depending on range value
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
public interface IWeapon {
    public void OnUse();
}

public class MeleeWeapon : IWeapon {
    public int damage;
    public string type; 
    public int range;

    public MeleeWeapon(int damage, string type, int range) {
        this.damage = damage;
        this.type = type;
        this.range = range;
    }

    public void OnUse() {

    }
}
