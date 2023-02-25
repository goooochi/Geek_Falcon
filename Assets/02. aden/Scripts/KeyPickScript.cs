using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//鍵に近づくと、Pickテイストを表示する機能
public class KeyPickScript : MonoBehaviour
{
    Text PickUI;
    private void Start()
    {
        PickUI = GameObject.Find("KeyPickText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("eneter");
            PickUI.text = "[E] Pick up the Key";
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUI.text = "";
        }
    }

    public void DeletePickUIText()
    {
        PickUI.text = "";
    }
}
