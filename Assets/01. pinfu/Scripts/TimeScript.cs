using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    private float time;
    public Text TimeText;
    public bool getTime;
    public static TimeScript instance;
    public int score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimeText.text = time.ToString("F2");

        if (getTime)
        {
            score = (int)time;
            getTime = false;
        }
    }
}
