using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGoalKeyScript : MonoBehaviour
{
   public int keyCount = 0;
    [SerializeField] private Text keyCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //keyCountText.text = "" + keyCount;
        //Debug.Log(keyCount);
    }
   /* public void KeyCall(string keyName)
    {
        if(keyName =="KeyTop")KeyUI[]
        else if(keyName == "KeyMiddle")
        else if(keyName == "KeyBottom")


    }*/
}
