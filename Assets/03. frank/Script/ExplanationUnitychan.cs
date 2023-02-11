using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationUnitychan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Key(Clone)")
        {
            Destroy(collision.gameObject);
            ExplanationSceneController.instance.isGetKey = true;
            Compass.instance.destination = GameObject.Find("ClearJudge").transform;
        }
    }
}
