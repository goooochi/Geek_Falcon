using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyPickScript : MonoBehaviour
{
    Text PickUI;
    private void Start()
    {
        PickUI = GameObject.Find("KeyPickText").GetComponent<Text>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUI.text = "[E] Pick up the Key";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("get");
                PickUI.text = "";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hanareta");
            PickUI.text = "";
        }
    }
}
