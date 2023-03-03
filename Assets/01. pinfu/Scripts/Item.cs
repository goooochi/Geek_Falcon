using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    GameObject pic4;
    GameObject pic5;
    GameObject lastText;
    bool goal = false;
    int count;

    public static string objName;
    private GameObject Panel;
    private GameObject keyNumObject;
    private Text keyNumText;

    public Text PickUI;

    Image Panel_image;
    private float alpha;
    private bool keyFlag;
    public static int keyCount;
    private string sceneName;
    private bool fadeout = false;
    private bool KeyPush = false;
    

    // Start is called before the first frame update
    void Start()
    {
        goal = false;
        count = 0;
        pic4 = GameObject.Find("pic4");
        pic5 = GameObject.Find("pic5");
        lastText = GameObject.Find("lasttext");
        pic4.SetActive(false);
        pic5.SetActive(false);
        lastText.SetActive(false);
        keyCount = 0;
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
        if(goal == true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                count += 1;
            }
            if(count == 1)
            {
                Destroy(pic4);
                pic5.SetActive(true);
            }else if (count == 2)
            {
                Destroy(pic5);
                lastText.SetActive(true);
            }else if(count == 3)
            {
                Time.timeScale = 1f;
                fadeout = true;
                sceneName = "Clear";
            }
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (Input.GetKey(KeyCode.E) && col.gameObject.tag == "Key")
        {
            objName = col.gameObject.name;
            Debug.Log(objName);
            keyCount += 1;
            Destroy(col.gameObject);
            Debug.Log(KeyPush);
            keyNumText.text = "Collect Key : " + keyCount;

            col.gameObject.SendMessage("DeletePickUIText");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal" && keyCount == 3)
        {
            TimeScript.instance.getTime = true;
            Debug.Log(keyCount);
            Time.timeScale = 0f;
            pic4.SetActive(true);
            goal = true;
        }
    }
    void FadeOut()
    {
        Panel.SetActive(true);
        alpha += 0.1f;
        Panel_image.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene(sceneName);
        }
    }
}
