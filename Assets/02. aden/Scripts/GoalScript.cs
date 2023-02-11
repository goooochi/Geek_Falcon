using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public bool canGoal = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canGoal == true)
        {
            SceneManager.LoadScene("Goal");
        }
    }

}
