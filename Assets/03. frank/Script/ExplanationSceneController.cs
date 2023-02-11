using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationSceneController : MonoBehaviour
{

    public GameObject unityChan;
    public GameObject enemy;
    public Camera mainCamera;

    public GameObject Fase1;
    public GameObject Fase2;
    public GameObject Fase3;
    public GameObject Fase4;

    public Text text1;
    

    private  float speed;
    private float time;

    public bool isGetKey = false;
    bool isThereAreEnemy = true;
    public bool isGoal = false;

    public Transform enemyCreatePosition;

    public static ExplanationSceneController instance;

    public object Compass { get; internal set; }

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
        speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(unityChan.gameObject.transform.position.x > 0 && unityChan.gameObject.transform.position.x < 8)
        {
            text1.color = GetAlphaColor(text1.color);
            Fase1.SetActive(true);

        }
        else
        {
            Fase1.SetActive(false);
        }

        if(unityChan.gameObject.transform.position.x > 20 && unityChan.gameObject.transform.position.x < 40)
        {
            Fase2.SetActive(true);
        }
        else
        {
            Fase2.SetActive(false);
        }

        if (isGetKey && unityChan.gameObject.transform.position.z > 41.6)
        {
            Fase3.SetActive(true);
        }
        else
        {
            Fase3.SetActive(false);
        }

        if (isGetKey && unityChan.gameObject.transform.position.x > 100 && unityChan.gameObject.transform.position.x < 120)
        {
            mainCamera.cullingMask = (1 << 6) + (1 << 8);

            if (isThereAreEnemy)
            {
                Debug.Log("AAA");
                enemy.SetActive(true);
                //Instantiate(enemy, enemyCreatePosition.position, Quaternion.identity);
                isThereAreEnemy = false;
            }
            
            Fase4.SetActive(true);
        }
        else
        {
            Fase4.SetActive(false);
        }

        if (isGoal)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManagement.instance.ToHome();
            }
        }





    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5f * speed;
        color.a = Mathf.Sin(time);

        return color;
    }


}
