using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverController instance;
    bool isPlaying;

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
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy_01" || collision.gameObject.name == "Enemy_02")
        {
            GameOver();
            if (SceneManager.GetActiveScene().name == "Explanation")
            {
                //ExplanationSceneController.instance.unityChan.transform.position = new Vector3()
            }
            isPlaying = false;
        }
    }

    public void GameOver()
    {
        
        gameOverUI.SetActive(true);
        
    }
}
