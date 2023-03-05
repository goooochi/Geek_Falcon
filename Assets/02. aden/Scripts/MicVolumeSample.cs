//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class MicVolumeSample : MonoBehaviour
//{
//    [SerializeField, Range(0f, 10f)] float m_gain = 1f; 
//    float m_volumeRate; 
//   [SerializeField] float isTriggerVolume;
//    private bool canTriggerChange = false;
//    private float falseTime=1;
//    // Use this for initialization

//#if UNITY_WEBGL && !UNITY_EDITOR
//        void Awake()
//        {
//            Microphone.Init();
//            Microphone.QueryAudioInput();
//        }
//#endif

//#if UNITY_WEBGL && !UNITY_EDITOR
//        void Update()
//        {
//            Microphone.Update();
//        }
//#endif

//    void Start()
//    {
//        AudioSource aud = GetComponent<AudioSource>();
//        if ((aud != null) && (Microphone.devices.Length > 0)) 
//        {
//            string devName = Microphone.devices[0]; 
//            int minFreq, maxFreq;
//            Microphone.GetDeviceCaps(devName, out minFreq, out maxFreq); 
//            aud.clip = Microphone.Start(devName, true, 2, minFreq);
//            aud.Play(); 
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //  Debug.Log(m_volumeRate);
//        if (falseTime > 0)
//        {
//            falseTime -= Time.deltaTime;
//        }
//        else if(canTriggerChange == true && falseTime < 0)
//        {
//            enemyScript.isTrigger = false;
//            canTriggerChange = false;
//        }
//    }

//    // 
//    private void OnAudioFilterRead(float[] data, int channels)
//    {
//        float sum = 0f;
//        for (int i = 0; i < data.Length; ++i)
//        {
//            sum += Mathf.Abs(data[i]); //
//        }
//        //
//        m_volumeRate = Mathf.Clamp01(sum * m_gain / (float)data.Length);
//        if (m_volumeRate > isTriggerVolume )
//        {
//            enemyScript.isTrigger = true;
//            canTriggerChange = true;
//            falseTime = 10;
//            Debug.Log("VolT");
//        }
//        else if(canTriggerChange == true && m_volumeRate < isTriggerVolume)
//        {
//            // enemyScript.isTrigger = false;
//            // canTriggerChange = false;
//          //  falseTime = 10;
//            Debug.Log("VolF");
//        }
//    }
//}