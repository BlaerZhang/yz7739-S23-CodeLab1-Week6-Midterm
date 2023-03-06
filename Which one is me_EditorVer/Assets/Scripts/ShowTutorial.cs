using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Sequence = DG.Tweening.Sequence;

public class ShowTutorial : MonoBehaviour
{
    private TextMeshProUGUI display;
    public TextMeshProUGUI skip;
    private Sequence firstTutorialAnimation;
    private Sequence tutorialAnimation;
    private Sequence skipAnimation;

    private bool isPlayingFT;
    private bool isPlayingT;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
        firstTutorialAnimation = DOTween.Sequence();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            firstTutorialAnimation
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("Which One is Me?", 1))
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("I...I don't know", 2))
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("Calm...There should be a way", 2))
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("I always have full control of my body...\nby my own free will", 4))
                .AppendInterval(2)
                .Append(display.DOText("", 0))
                .Append(display.DOText("Press ←/→ to Turn Myself Clockwise/Counterclockwise", 3))
                .AppendInterval(2)
                .Append(display.DOText("", 0))
                .Append(display.DOText("Press ↓ to Stand At Ease", 2))
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("Once I know the answer", 2))
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("Just Click on the Student that I think is me", 3))
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("But I should be very careful...", 2))
                .AppendInterval(1)
                .Append(display.DOText("", 0))
                .Append(display.DOText("I only have one chance", 1))
                .AppendInterval(2)
                .Append(display.DOText("", 0))
                .Append(display.DOText("Press T To review the control", 1))
                .AppendInterval(2)
                .Append(display.DOText("", 0));
            
            firstTutorialAnimation.Play();
            
            skipAnimation = DOTween.Sequence();
            skipAnimation
                .Append(skip.DOText("", 0))
                .AppendInterval(1)
                .Append(skip.DOText("Press S to Skip Tutorial", 0))
                .AppendInterval(1)
                .SetLoops(-1,LoopType.Restart);
            
            skipAnimation.Play();
        }

        tutorialAnimation = DOTween.Sequence();
        tutorialAnimation
            .Append(display.DOText("", 0))
            .Append(display.DOText("OK...a quick review", 1))
            .AppendInterval(1)
            .Append(display.DOText("", 0))
            .Append(display.DOText("I always have full control of my body\nby my own free will", 4))
            .AppendInterval(2)
            .Append(display.DOText("", 0))
            .Append(display.DOText("Press ←/→ t Turn Myself Clockwise/Counterclockwise", 3))
            .AppendInterval(2)
            .Append(display.DOText("", 0))
            .Append(display.DOText("Press ↓ to Stand At Ease", 2))
            .AppendInterval(1)
            .Append(display.DOText("", 0))
            .Append(display.DOText("Just Click on the Student that I think is me", 3))
            .AppendInterval(1)
            .Append(display.DOText("", 0))
            .Append(display.DOText("But I only have one chance", 1))
            .AppendInterval(2)
            .Append(display.DOText("", 0))
            .Pause();
        tutorialAnimation.SetAutoKill(false);
    }

    // Update is called once per frame
    void Update()
    {
        isPlayingFT = firstTutorialAnimation.IsPlaying();
        isPlayingT = tutorialAnimation.IsPlaying();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (isPlayingFT == false) 
            {
                skipAnimation.Kill();
                skip.text = "";
            }
        }
        
        if (!isPlayingFT && !isPlayingT)
        {
            if (MouseClick.isInGame && !MouseClick.isWinning)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    tutorialAnimation.Restart();
                }
            }
            
            if (MouseClick.hP > 0) 
            {
                MouseClick.isInGame = true;
            }
        }

        if (isPlayingT | isPlayingFT)
        {
            MouseClick.isInGame = false;
        }

        if (isPlayingFT)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                firstTutorialAnimation.Kill();
                display.text = "";
                skip.text = "";
            }
        }
    }
}

