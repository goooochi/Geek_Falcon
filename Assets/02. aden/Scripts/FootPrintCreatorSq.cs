using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintCreatorSq : MonoBehaviour
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

    void FootStepRightSq()
    {
        Instantiate(footStepRight, transform.position, transform.rotation);
        Laser_Create_PlayerSq.instance.PlayerLaserCreate();
        audioSource.Play();
    }

    void FootStepLeftSq()
    {
        Instantiate(footStepLeft, transform.position, transform.rotation);
        Laser_Create_PlayerSq.instance.PlayerLaserCreate();
        audioSource.Play();
    }
}
