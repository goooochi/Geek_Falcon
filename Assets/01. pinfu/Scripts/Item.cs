using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject Panel;
    Image Panel_image;
    private float alpha;
    private bool keyFlag;
    private int keyCount;
    private string sceneName;
    private bool fadeout = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            FadeOut();
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Key" && Input.GetKeyDown(KeyCode.E))
        { 
            keyCount += 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Goal" && keyCount >= 3)
        {
            fadeout = true;
            sceneName = "Clear";
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
}
