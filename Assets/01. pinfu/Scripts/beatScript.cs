using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private IEnumerator coroutine;
    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
        coroutine = TempoMake();
        StartCoroutine(coroutine);
    }
    IEnumerator TempoMake()
    {
        while (true)
        {
            float INTERVAL_SECONDS = Random.value;
            yield return
             new WaitForSecondsRealtime(INTERVAL_SECONDS);
            audioSource.Play();
        }
    }
}