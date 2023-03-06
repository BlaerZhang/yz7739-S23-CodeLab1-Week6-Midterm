using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class NewGiveOrder : MonoBehaviour
{
    private Animator newStudent;
    public TextMeshPro dialog;
    public AudioSource allTurnAudio;
    public AudioSource allAtEaseAudio;
    public AudioSource turnVoice;
    [HideInInspector] public int directionState = 1;
    // [HideInInspector] bool isAtEase = false;

    void Start()
    {
        newStudent = GetComponent<Animator>();
        InvokeRepeating("GivingOrder",0f,3f);
    }
    
    void Update()
    {
        newStudent.SetInteger("DirectionState", directionState);
        // studentAtonomy.SetBool( "isAtEase", isAtEase);
    }

    void GivingOrder()
    {
        int randomOrder = Random.Range(0, 2);
        turnVoice.Play();
        if (randomOrder == 0)
        {
            dialog.text = "< Turn Right!";
            Invoke("TurnRight", 1.25f);
        }

        if (randomOrder == 1) 
        {
            dialog.text = "< Turn Left!";
            Invoke("TurnLeft", 1.25f);
        }
    }
    
    private void TurnRight()
    {
        dialog.text = "";
        if (directionState == 1)
        {
            directionState = 4;
        }
        else directionState -= 1;
        allTurnAudio.Play();
    }

    private void TurnLeft()
    {
        dialog.text = "";
        if (directionState == 4)
        {
            directionState = 1;
        }
        else directionState += 1;
        allTurnAudio.Play();
    }
}
