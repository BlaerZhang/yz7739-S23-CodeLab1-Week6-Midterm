using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator student;
    [HideInInspector] int DirectionState = 1;
    [HideInInspector] bool isAtEase = false;
    // Start is called before the first frame update
    void Start()
    {
        student = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            if (isAtEase == false)
            {
                if (DirectionState == 4)
                {
                    DirectionState = 1;
                }
                else DirectionState += 1;
                student.SetInteger("DirectionState", DirectionState);
            }
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isAtEase == false)
            {
                if (DirectionState == 1)
                {
                    DirectionState = 4;
                }
                else DirectionState -= 1;
                student.SetInteger("DirectionState", DirectionState);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (DirectionState == 1 || DirectionState == 3)
            {
                if (isAtEase == false)
                {
                    isAtEase = true;
                }
                else isAtEase = false;
                student.SetBool( "isAtEase", isAtEase);
            } 
        }
            
    }
}
