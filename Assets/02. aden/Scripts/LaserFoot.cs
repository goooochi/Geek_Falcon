using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFoot : MonoBehaviour
{
    [SerializeField] private GameObject beet;
    [SerializeField] private GameObject[] beetPosition;
    private bool instantiateCount =Å@true;
    private GameObject afterBeet;
    private Rigidbody rb;
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
        if (other.transform.tag != "Player" && instantiateCount == true)
        {
            for (int i = 0; i < beetPosition.Length; i++)
            {
               afterBeet = Instantiate(beet, beetPosition[i].transform.position, Quaternion.identity);
                rb = afterBeet.GetComponent<Rigidbody>();
              //  rb.velocity= new Vector3(beetPosition[i].transform.rotation.x * 100, beetPosition[i].transform.rotation.y * 100, beetPosition[i].transform.rotation.z * 100);
                rb.velocity = beetPosition[i].transform.forward * 10;
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
