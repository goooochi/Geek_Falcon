using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compass_image_alpha : MonoBehaviour
{
    public Color KeyColor;
    // Start is called before the first frame update
    void Start()
    {
        KeyColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeAlpha()
    {
        KeyColor.a = 0;
        GetComponent<Image>().color = KeyColor;
    }
}
