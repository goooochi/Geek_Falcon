using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Fade : MonoBehaviour
{
    private GameObject Panel;
    Image Panel_image;
    private float alpha;
    private bool fadeout = false;
    private bool fadein;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("FadePanel");
        Panel_image = Panel.GetComponent<Image>();
        alpha = Panel_image.color.a;
        fadein = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            Panel.SetActive(true);
            FadeOut();
        }
        if (fadein == true)
        {
            FadeIn();
        }
    }
    void FadeOut()
    {
        alpha += 0.001f;
        Panel_image.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene(sceneName);
        }
    }
    void FadeIn()
    {
        alpha -= 0.001f;
        Panel_image.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadein = false;
            Panel.SetActive(false);
        }
    }
    public void RetryButton()
    {
        fadeout = true;
        sceneName = "Stage";
    }
    public void TitleButton()
    {
        fadeout = true;
        sceneName = "Title";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nomal_Enemy" || other.gameObject.tag == "Original_Enemy")
        {
            fadeout = true;
            sceneName = "GameOver";
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.None;
        }
    }
}