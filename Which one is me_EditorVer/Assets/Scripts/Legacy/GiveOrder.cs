using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiveOrder : MonoBehaviour
{
    private Animator studentAtonomy;
    public TextMeshPro dialog;
    [HideInInspector] public int DirectionState = 1;
    // [HideInInspector] bool isAtEase = false;

    void Start()
    {
        studentAtonomy = GetComponent<Animator>();
        InvokeRepeating("GivingOrder",2f,5f);
    }
    
    void Update()
    {
        studentAtonomy.SetInteger("DirectionState", DirectionState);
        // studentAtonomy.SetBool( "isAtEase", isAtEase);
    }

    void GivingOrder()
    {
        int randomOrder = Random.Range(0, 2);
        if (randomOrder == 0)
        {
            dialog.text = "- Turn Right!";
            Invoke("TurnRight", 1f);
        }

        if (randomOrder == 1) 
        {
            dialog.text = "- Turn Left!";
            Invoke("TurnLeft", 1f);
        }
    }
    
    private void TurnRight()
    {
        dialog.text = "";
        if (DirectionState == 4)
        {
            DirectionState = 1;
        }
        else DirectionState += 1;
    }

    private void TurnLeft()
    {
        dialog.text = "";
        if (DirectionState == 1)
        {
            DirectionState = 4;
        }
        else DirectionState -= 1;
    }
}
