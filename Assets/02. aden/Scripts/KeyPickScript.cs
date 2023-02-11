using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyPickScript : MonoBehaviour
{
    public Text PickUI;
    PlayerGoalKeyScript playerGoalKeyScript;
    [SerializeField] private GameObject player;
    private void Start()
    {
        playerGoalKeyScript = player.GetComponent<PlayerGoalKeyScript>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUI.text = "EÉLÅ[Ç≈åÆÇèEÇ§";
            if (Input.GetKeyDown(KeyCode.E))
            {
                /*   ExecuteEvents.Execute<IEventCaller>(
                       target: player,
                       eventData: null,
                       functor: KeyCaller);

                       */
                playerGoalKeyScript.keyCount++;
                PickUI.text = "";
                Destroy(this.gameObject);
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
 /*  void KeyCaller(IEventCaller inf,BaseEventData eventData)
    {
        inf.KeyCall(this.gameObject.name);

        
    }*/
}
