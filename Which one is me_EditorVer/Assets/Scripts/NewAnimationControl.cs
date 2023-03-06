using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NewAnimationControl : MonoBehaviour
{
    private Animator student;
    public AudioSource turnAudio;
    public AudioSource atEaseAudio;
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
                turnAudio.Play();
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
                turnAudio.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isAtEase == false) 
            { 
                isAtEase = true; 
            }
            else isAtEase = false; 
            student.SetBool( "isAtEase", isAtEase);
            atEaseAudio.Play();
        }
    }
}
