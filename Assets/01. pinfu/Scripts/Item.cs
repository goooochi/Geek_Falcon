using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private GameObject Panel;
    private GameObject keyNumObject;
    private Text keyNumText;
    Image Panel_image;
    private float alpha;
    private bool keyFlag;
    private int keyCount;
    private string sceneName;
    private bool fadeout = false;
    private bool KeyPush = false;
     
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("FadePanel");
        Panel_image = Panel.GetComponent<Image>();
        alpha = Panel_image.color.a;
        keyNumObject = GameObject.Find("KeyNumText");
        keyNumText = keyNumObject.GetComponent<Text>();
        keyNumText.text = "Collect Key : 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            FadeOut();
        }
    }
    private void OnTriggerStay(Collider col)
    {
        Debug.Log("hit");
        if (Input.GetKey(KeyCode.E) && col.gameObject.tag == "Key")
        {
            keyCount += 1;
            Destroy(col.gameObject);
            Debug.Log(KeyPush);
            keyNumText.text = "Collect Key : " + keyCount;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log(keyCount);
            fadeout = true;
            sceneName = "Clear";
        }
    }
    void FadeOut()
    {
        Panel.SetActive(true);
        alpha += 0.001f;
        Panel_image.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene(sceneName);
        }
    }
}
