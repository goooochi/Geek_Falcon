using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compass_image_alpha : MonoBehaviour
{
    GameObject Key1;
    GameObject Key2;
    GameObject Key3;
    Image Key1_image;
    Image Key2_image;
    Image Key3_image;
    private float alpha1;
    private float alpha2;
    private float alpha3;
    // Start is called before the first frame update
    void Start()
    {
        Key1 = GameObject.Find("Maker2");
        Key2 = GameObject.Find("Maker3");
        Key3 = GameObject.Find("Maker4");
        
        Key1_image = Key1.GetComponent<Image>();
        Key2_image = Key2.GetComponent<Image>();
        Key3_image = Key3.GetComponent<Image>();

        alpha1 = Key1_image.color.a;
        alpha2 = Key2_image.color.a;
        alpha3 = Key3_image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(Item.objName == "default1")
        {
            Debug.Log("a");
            alpha1 = 0;
            Key1_image.color = new Color(0, 0, 0, alpha1);
        }
        if (Item.objName == "default2")
        {
            alpha2 = 0;
            Key2_image.color = new Color(0, 0, 0, alpha2);
        }
        if (Item.objName == "default3")
        {
            alpha3 = 0;
            Key3_image.color = new Color(0, 0, 0, alpha3);
        }
    }
}
