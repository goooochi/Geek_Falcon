using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compass_image_alpha : MonoBehaviour
{
    GameObject com;
    GameObject Key1;
    GameObject Key2;
    GameObject Key3;
    Image Key1_image;
    Image Key2_image;
    Image Key3_image;
    float alpha1;
    float alpha2;
    float alpha3;
    // Start is called before the first frame update
    void Start()
    {
        Key1 = transform.GetChild(0).gameObject;
        Key2 = transform.GetChild(1).gameObject; 
        Key3 = transform.GetChild(2).gameObject;
        
        Key1_image = Key1.GetComponent<Image>();
        Key2_image = Key2.GetComponent<Image>();
        Key3_image = Key3.GetComponent<Image>();

        alpha1 = Key1_image.color.a;
        alpha2 = Key2_image.color.a;
        alpha3 = Key3_image.color.a;
        Debug.Log(alpha1);
    }

    // Update is called once per frame
    void Update()
    {
        com.SetActive(false);
        if (Item.objName == "default1")
        {
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
