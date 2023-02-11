using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject gameClearUI;
    float time = 0;
    public Text scoreText;
    public bool isGaming;

    public static GameClear instance;


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
        isGaming = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGaming)
        {
            time += Time.deltaTime;
        }
        
    }

    public void OpenDoor()
    {
        leftDoor.SetActive(false);
        rightDoor.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.layer == 9)
        {
            gameClearUI.SetActive(true);
            isGaming = false;
            if(SceneManager.GetActiveScene().name == "Explanation")
            {
                ExplanationSceneController.instance.isGoal = true;
            }
            
            scoreText.text = "Time : " + time.ToString();
        }

    }

    public void ToHome()
    {
        Debug.Log("Title");
        SceneManager.LoadScene("Title");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }
}
