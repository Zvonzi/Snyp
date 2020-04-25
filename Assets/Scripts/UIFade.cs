 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{

    public static UIFade instance;

    public Image fadeScreenImage;
    public float fadeSpeed;

    private bool fadeToBlack;
    private bool fadeFromBlack;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        if (fadeToBlack)
        {
            fadeScreenImage.color = new Color(fadeScreenImage.color.r, fadeScreenImage.color.g, fadeScreenImage.color.b,
                                    Mathf.MoveTowards(fadeScreenImage.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreenImage.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
        if (fadeFromBlack)
        {
            fadeScreenImage.color = new Color(fadeScreenImage.color.r, fadeScreenImage.color.g, fadeScreenImage.color.b,
                                    Mathf.MoveTowards(fadeScreenImage.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreenImage.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        fadeToBlack = true;
        fadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        fadeToBlack = false;
        fadeFromBlack = true;
    }
}
