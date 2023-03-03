using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyScript : MonoBehaviour
{
    [SerializeField] GameObject pic1;
    [SerializeField] GameObject pic2;
    [SerializeField] GameObject pic3;
    [SerializeField] GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        pic1.SetActive(false);
        pic2.SetActive(false);
        pic3.SetActive(false);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Item.keyCount == 1)
        {
            pic1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(pic1);
            }
        }
        if(Item.keyCount == 2)
        {
            pic2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(pic2);
            }
        }
        if (Item.keyCount == 3)
        {
            pic3.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(pic3);
                text2.SetActive(true);
                if (text2.transform.position.y >= 1100)
                {
                    text2.SetActive(false);
                }
                
            }
        }
    }
}
