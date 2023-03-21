using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    public float moveSpeed = 1;
    public Rigidbody2D playerRb2d;


    private void Awake()
    {
        instance = this; //set an easy singleton
    }
  
    void Start()
    {
        playerRb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //a wasd controller that provides a constant speed, and won't function when player's moving
        if (playerRb2d.velocity == Vector2.zero)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerRb2d.velocity = Vector2.left * moveSpeed;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerRb2d.velocity = Vector2.right * moveSpeed;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                playerRb2d.velocity = Vector2.up * moveSpeed;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerRb2d.velocity = Vector2.down * moveSpeed;
            }   
        }
    }
} 
