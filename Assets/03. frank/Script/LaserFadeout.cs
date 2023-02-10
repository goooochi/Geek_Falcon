using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFadeout : MonoBehaviour
{

    // フェードアウトするまでの時間(10sec)
    float fadeTime = 1f;
    private float time;
    private TrailRenderer render;
    private GameObject parent;


    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<TrailRenderer>();
        parent = transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < fadeTime)
        {
            float alpha = 1.0f - time / fadeTime;
            Color color = render.material.color;
            color.a = alpha;
            render.material.color = color;
        }
        else
        {
            Destroy(parent);
            Destroy(gameObject);
        }
    }
}
