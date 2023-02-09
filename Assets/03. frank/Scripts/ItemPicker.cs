using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera)
        {
            RaycastHit hit;
            if(Physics.Raycast(mainCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f)),out hit,100.0f))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
