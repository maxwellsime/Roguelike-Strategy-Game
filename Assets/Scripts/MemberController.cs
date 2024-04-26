using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MemberController : MonoBehaviour
{   
    private Vector2 desiredPosition;
    private float speed;

    private void Start() {
        speed = gameObject.GetComponent<CharacterObject>().speed;
        desiredPosition = transform.position;
    }

    private void Update() {
        this.transform.position = Vector2.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);
    }

    public void Move(Vector2 inputPosition) {
        desiredPosition = inputPosition;
    }
}
