using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObeyOrder : MonoBehaviour
{
    private Animator newStudent;
    public NewGiveOrder newGiveOrder;
    
    // Start is called before the first frame update
    void Start()
    {
        newStudent = GetComponent<Animator>();
        InvokeRepeating("listenOrder", 1.3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void listenOrder()
    {
        newStudent.SetInteger("DirectionState", newGiveOrder.directionState);
        // studentAtonomy.SetBool( "isAtEase", isAtEase);
    }
}
