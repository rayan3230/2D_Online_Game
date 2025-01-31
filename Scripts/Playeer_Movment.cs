using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Playeer_Movment : NetworkBehaviour
{
    
 
     public float moveSpeed = 5f; // Speed of the player

    public void Move()
    {
           // Get input from horizontal (A/D or Left/Right) and vertical (W/S or Up/Down)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Move the player
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
    void Update()
    {
        if(!IsOwner) return ;
        Move();
        
    }
    
}


