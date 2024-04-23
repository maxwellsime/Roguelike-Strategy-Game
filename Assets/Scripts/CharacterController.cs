using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
private Vector2 lastPosition;
    private bool moving;

    private float speed;

    private void Start() {
        speed = gameObject.GetComponent<CharacterObject>().speed;
    }

    private void Update() {
        if(Input.GetMouseButton(0)) {
            lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
            
            if (moving && (Vector2)transform.position != lastPosition) {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    lastPosition,
                    step
                );
            } else {
                moving = false;
            }
        }
    }
}
