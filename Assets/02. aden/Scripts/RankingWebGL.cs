using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingWebGL : MonoBehaviour
{
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

   
}
