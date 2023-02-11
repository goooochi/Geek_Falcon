using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGoalKeyScript : MonoBehaviour
{
   public int keyCount;
    GameObject keyCountUI;
    GameObject goal;
     private Text keyCountText;

    GoalScript goalScript;
    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("goalCube");
        goalScript = goal.GetComponent<GoalScript>();
        keyCountUI = GameObject.Find("Keys");
        keyCountText = keyCountUI.GetComponent<Text>();
        keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCount < 3)
        {
            keyCountText.text = "Œ®‚Ì”~" + keyCount;
        }
        else if(keyCount >= 3)
        {
            keyCountText.text = "”à‚ð–ÚŽw‚¹";
            goalScript.canGoal = true;
        }
  
    }
   /* public void KeyCall(string keyName)
    {
        if(keyName =="KeyTop")KeyUI[]
        else if(keyName == "KeyMiddle")
        else if(keyName == "KeyBottom")


    }*/
}
