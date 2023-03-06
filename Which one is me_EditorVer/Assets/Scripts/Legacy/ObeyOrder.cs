using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeyOrder : MonoBehaviour
{
    private Animator student;
    public GiveOrder giveOrder;
    // Start is called before the first frame update
    void Start()
    {
        student = GetComponent<Animator>();
        InvokeRepeating("listenOrder", 3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void listenOrder()
    {
        student.SetInteger("DirectionState", giveOrder.DirectionState);
        // studentAtonomy.SetBool( "isAtEase", isAtEase);
    }
}
