using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldNPC : MonoBehaviour
{
    public Vector2 desired_position;
    public bool busy = false;
    public Party party

    void Start()
    {
    }

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, desiredPosition, party.speed * Time.deltaTime);
    }

    void Adventure() 
    { 
        // make next decision
    }

    void Interact()
    { 
        // Open dialogue
        // Enable combat/discussion/trading
        // ?NPC Interactions with other NPCS?
    }
}
