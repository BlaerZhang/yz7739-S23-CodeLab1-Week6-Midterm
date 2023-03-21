using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WallTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if player touches the wall
        {
            PlayerControl.instance.playerRb2d.velocity = Vector2.zero; //stop the player
            PlayerControl.instance.transform.position = new Vector3(
                Mathf.RoundToInt(PlayerControl.instance.transform.position.x),
                Mathf.RoundToInt(PlayerControl.instance.transform.position.y)); //set player's position into the slot
        }
    }
}
