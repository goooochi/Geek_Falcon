using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_color : MonoBehaviour {
    public static int color = 0;
	// Use this for initialization
	void Start () {
        if ( color ==0 )GetComponent<Renderer>().material.color = Color.magenta;
        if (color == 1) GetComponent<Renderer>().material.color = Color.cyan;
        if (color == 2) GetComponent<Renderer>().material.color = Color.yellow;
        if (color == 3) GetComponent<Renderer>().material.color = Color.magenta;
        if (color == 4) GetComponent<Renderer>().material.color = Color.blue;
        if (color == 5) GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update () {
    }
}
