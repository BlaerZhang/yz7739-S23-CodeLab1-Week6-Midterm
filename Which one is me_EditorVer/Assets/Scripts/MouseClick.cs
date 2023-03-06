using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class MouseClick : MonoBehaviour
{
    public static int hP;
    public TextMeshProUGUI subText;
    public TextMeshProUGUI systemText;
    public static bool isInGame = true;
    public static bool isWinning = false;
    public Camera mainCamera;
    private Sequence lostMyself;
    private Sequence findMyself;
    private Sequence theEnd;

    public GameObject upMask;
    public GameObject downMask;
    // Start is called before the first frame update
    void Start()
    {
        hP = 1;
        isWinning = false;
        lostMyself = DOTween.Sequence();
        lostMyself
            .Append(systemText.DOText("LOST", 0))
            .Append(mainCamera.DOShakePosition(0.5f, 0.2f))
            .Append(systemText.DOText("LOST MYSELF", 0))
            .Append(mainCamera.DOShakePosition(0.5f, 0.2f))
            .Append(subText.DOText("Press R to Try Again",1))
            .Pause();
        
        findMyself = DOTween.Sequence();
        findMyself
            .Append(systemText.DOText("There", 0))
            .Append(mainCamera.DOShakePosition(0.5f, 0.2f))
            .Append(systemText.DOText("There I", 0))
            .Append(mainCamera.DOShakePosition(0.5f, 0.2f))
            .Append(systemText.DOText("There I Am", 0))
            .Append(mainCamera.DOShakePosition(0.5f, 0.2f))
            .Append(subText.DOText("Press Any Key to the Next Level",1))
            .Pause();

        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            theEnd = DOTween.Sequence();
        theEnd
            .Append(mainCamera.GetComponent<Transform>().DOMoveX(25,5))
            .Insert(0,upMask.GetComponent<Transform>().DOMoveY(21.5f,5))
            .Insert(0,downMask.GetComponent<Transform>().DOMoveY(-21.5f,5))
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("Phew...", 1))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("So this is how the view looks like from above...", 3))
            .AppendInterval(2)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("It's so good to sneak onto the rooftop", 3))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("Look down on lives", 1))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("Leave head empty for a while", 2))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("Catch some breeze", 1))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("...", 1))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("'We sat and drank'", 1))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("'with the sun on our shoulders'", 1))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("'and felt like free men.'", 1))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(subText.DOText("I wish this moment could last forever", 3))
            .AppendInterval(1)
            .Append(subText.DOText("", 0))
            .Append(systemText.DOText("The", 0))
            .Append(mainCamera.DOShakePosition(0.5f, 0.2f))
            .Append(systemText.DOText("The End", 0))
            .Append(mainCamera.DOShakePosition(0.5f, 0.2f))
            .Append(subText.DOText("A Game by Blaer and Haotian",1))
            .Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // hPText.text = hP.ToString() + " Tries Left";
        if (isInGame && !isWinning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hP > 0) 
                { 
                    hP -= 1; 
                }
            }
        }
        if (hP <= 0)
        {
            isInGame = false;
            // systemText.text = "Lose Myself\nPress R to Try Again"; 
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                theEnd.Play();
            }
            
            if (SceneManager.GetActiveScene().buildIndex != 10)
            {
                lostMyself.Play();
                if (Input.GetKeyDown(KeyCode.R)) 
                {
                    Scene currentScene = SceneManager.GetActiveScene(); 
                    SceneManager.LoadScene(currentScene.name);
                }
            }
        }

        if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0)))
        {
            if (isWinning)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
            }
        }
        
    }

    private void OnMouseDown()
    {
        if (isInGame)
        {
            isInGame = false;
            isWinning = true;
            hP += 1;
            findMyself.Play();
        }
    }
}
