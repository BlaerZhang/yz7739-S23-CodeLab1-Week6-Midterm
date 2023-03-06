using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FreePractice : MonoBehaviour
{
    private Animator newStudent;
    public TextMeshPro dialog;
    public AudioSource turnAudio;
    public AudioSource atEaseAudio;
    [HideInInspector] public int directionState = 1;
    // Start is called before the first frame update
    void Start()
    {
        newStudent = GetComponent<Animator>();
        InvokeRepeating("Practice",1f,0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        newStudent.SetInteger("DirectionState", directionState);
    }
    
    void Practice()
    {
        int randomOrder = Random.Range(0, 2);
        dialog.text = "";
        if (randomOrder == 0)
        {
            if (directionState == 1)
            {
                directionState = 4;
            }
            else directionState -= 1;
            turnAudio.Play();
        }

        if (randomOrder == 1) 
        {
            if (directionState == 4)
            {
                directionState = 1;
            }
            else directionState += 1;
            turnAudio.Play();
        }
    }
}
