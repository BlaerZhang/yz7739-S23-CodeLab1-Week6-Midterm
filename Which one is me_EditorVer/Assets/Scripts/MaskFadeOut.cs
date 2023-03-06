using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaskFadeOut : MonoBehaviour
{
    private Sequence fadeAnimation;
    private Sequence firstFadeAnimation;
    private bool isFirstFading;
    // Start is called before the first frame update
    void Start()
    {
        fadeAnimation = DOTween.Sequence();
        firstFadeAnimation = DOTween.Sequence();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            firstFadeAnimation.AppendInterval(8)
                .Append(gameObject.GetComponent<SpriteRenderer>().DOFade(0, 9));
            firstFadeAnimation.Play();
        }
        else
        {
            fadeAnimation.AppendInterval(0)
                .Append(gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1));
            fadeAnimation.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        isFirstFading = firstFadeAnimation.IsPlaying();
        if (isFirstFading)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                firstFadeAnimation.Kill();
                gameObject.SetActive(false);
            }
        }
    }
}
