using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChangeSound : MonoBehaviour
{
    private TMP_Text text;
    private bool hasTextChanged;
    public AudioSource typeSound;
    // Start is called before the first frame update
    void Start()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTextChanged)
        {
            typeSound.Play();
            hasTextChanged = false;
        }
    }
    
    void ON_TEXT_CHANGED(Object obj)
    {
        if (obj == text)
            hasTextChanged = true;
    }
}
