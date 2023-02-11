using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    [SerializeField] GameObject SpotLight;
    private bool isLight = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(isLight == false) {
                SpotLight.SetActive(true);
                isLight = true;
            }
           else if (isLight == true)
            {
                SpotLight.SetActive(false);
                isLight = false;
            }

        }
    }
}
