using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintCreator : MonoBehaviour
{
    public GameObject footStepRight;
    public GameObject footStepLeft;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    

    public void OnCollisionEnter(Collision collision)
    {
        
    }

    void FootStepRight()
    {
        Instantiate(footStepRight, transform.position, transform.rotation);
        Laser_Create_Player.instance.PlayerLaserCreate();
        audioSource.Play();
    }

    void FootStepLeft()
    {
        Instantiate(footStepLeft, transform.position, transform.rotation);
        Laser_Create_Player.instance.PlayerLaserCreate();
        audioSource.Play();
    }
}
