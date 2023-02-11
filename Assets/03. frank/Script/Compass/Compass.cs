using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{

    [SerializeField] Image image;
    [SerializeField] Transform player;
    [SerializeField] public Transform destination;

    RectTransform rt;

    public static Compass instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rt = image.rectTransform;
        destination = GameObject.Find("Key(Clone)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = destination.position - player.position;

        var axis = Vector3.Cross(player.forward, diff);

        var angle = Vector3.Angle(player.forward, diff)* (axis.y < 0 ? -1 : 1);

        rt.transform.rotation = Quaternion.AngleAxis(-angle,Vector3.forward);
    }
}
