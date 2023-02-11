using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyPickScript : MonoBehaviour
{
    public Text PickUI;
    [SerializeField] private GameObject player;
    private void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUI.text = "[E] Pick up the Key";
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUI.text = "";
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
}
