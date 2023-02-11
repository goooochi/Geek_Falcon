/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyPickScript : MonoBehaviour
{
    GameObject PickUI;
    Text pickText;
  //  PlayerGoalKeyScript playerGoalKeyScript;
    [SerializeField] private GameObject player;
    private void Start()
    {
        player = GameObject.Find("unitychan(Clone)");
       // playerGoalKeyScript = player.GetComponent<PlayerGoalKeyScript>();
        PickUI = GameObject.Find("E");
        pickText = PickUI.GetComponent<Text>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickText.text = "EÉLÅ[Ç≈åÆÇèEÇ§";
            if (Input.GetKeyDown(KeyCode.E))
            {
                   ExecuteEvents.Execute<IEventCaller>(
                       target: player,
                       eventData: null,
                       functor: KeyCaller);

                       
               // playerGoalKeyScript.keyCount++;
               pickText.text = "";
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickText.text = "";
        }
    }
  void KeyCaller(IEventCaller inf,BaseEventData eventData)
    {
        inf.KeyCall(this.gameObject.name);

        
    }
}*/
