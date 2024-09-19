using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.InputSystem;
using UnityEditor.U2D.Animation;

public class OverworldController : MonoBehaviour 
{
    public Party party;
    public Status status;
    public float speed = 10f;
    private PlayerInputActions.OverworldActions inputActions = new PlayerInputActions().Overworld;
    private Vector2 desiredPosition;
    private Bounds mapBounds;

    private void Start() {
        desiredPosition = transform.position;
        status = Status.ACTIVE;
        party = new Party(new PlayerCharacter());
        mapBounds = GameObject.Find("Map").GetComponent<SpriteRenderer>().bounds;
    }

    private void Update() {
        this.transform.position = Vector2.MoveTowards(transform.position, desiredPosition, party.speed * Time.deltaTime);
    }

    public void OnMove() {
        Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if(status != Status.BUSY) {
            Vector2 memberSize  = this.gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds.size;
            Vector2 arenaMaximum = mapBounds.max;
            Vector2 arenaMinimum = mapBounds.min;
            Vector2 clampedPosition = new(
                Mathf.Clamp(inputPosition.x, arenaMinimum.x + memberSize.x / 2, arenaMaximum.x - memberSize.x / 2),
                Mathf.Clamp(inputPosition.y, arenaMinimum.y + memberSize.y / 2, arenaMaximum.y - memberSize.y / 2)
            );
            
            status = Status.ACTIVE;
            desiredPosition = clampedPosition;
        }
    }

    public enum Status {
        ACTIVE,
        BUSY
    }
}
