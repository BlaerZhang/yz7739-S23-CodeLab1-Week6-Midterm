using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.instance.GetComponent<ASCIILevelEditor>().HitExit(); //when player hit exit, set current level +1
        }
    }
}
