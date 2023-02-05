using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFoot : MonoBehaviour
{
    [SerializeField] private GameObject beet;
    [SerializeField] private GameObject[] beetPosition;
    private bool instantiateCount =Å@true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player" && instantiateCount==true)
        {
            for (int i = 0; i < beetPosition.Length; i++)
            {
                Instantiate(beet, beetPosition[i].transform.position, Quaternion.identity);
            }
            instantiateCount = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag != "Player" && instantiateCount == false)
        {
            instantiateCount = true;
        }
    }


}
