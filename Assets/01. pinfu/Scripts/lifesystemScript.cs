using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lifesystemScript : MonoBehaviour
{
    public GameObject warningImage;
    Image warning_image;
    private float alpha;
    private float life;
    private float life_max = 1.00f;
    public string SceneName;
    private float timer = 0;
    private float stopTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        warning_image = warningImage.GetComponent<Image>();
        alpha = warning_image.color.a;
        alpha = 0;
        life = life_max;
        warningImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            life -= 0.01f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                life -= 0.05f;
            }
            timer = 0.0f;
        }
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
        {
            stopTimer += Time.deltaTime;
            if (Input.GetKey(KeyCode.Q))
            {
                if (stopTimer >= 0.5f)
                {
                    life += 0.05f;
                    if (life >= life_max)
                    {
                        life = life_max;
                    }
                    stopTimer = 0.0f;
                }
            }
        }
        WarningSystem();
    }

    void WarningSystem()
    { 
        if (life <= life_max * 0.3)
        {
            warningImage.SetActive(true);
            if (alpha < 0.3f)
            {
                alpha += 0.1f;
                warning_image.color = new Color(255, 255, 255, alpha);
            }
            else
            {
                alpha = 1 - (life * 2);
                warning_image.color = new Color(255, 255, 255, alpha);
            }
            if (alpha >= 1)
            {
                SceneManager.LoadScene(SceneName);
            }
        }
        else
        {
            warningImage.SetActive(false);
        }
    }
}
