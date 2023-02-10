using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public GameObject Panel;
    public string SceneName;
    Image Panel_image;
    private float alpha;
    private bool fadeout = false;
    private bool fadein;
    
    // Start is called before the first frame update
    void Start()
    {
        Panel_image = Panel.GetComponent<Image>();
        alpha = Panel_image.color.a;
        fadein = true;
    }

    // Update is called once per frame
    void Update()
    {
     if (fadeout == true)
        {
            FadeOut();
        }
     if (fadein == true)
        {
            FadeIn();
        }
     if (Input.GetMouseButtonDown(0))
        {
            fadeout = true;
        } 
    }
    void FadeOut()
    {
        alpha += 0.001f;
        Panel_image.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene(SceneName);
        }
    }
    void FadeIn()
    {
        alpha -= 0.001f;
        Panel_image.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadein = false;
        }
    }
}
