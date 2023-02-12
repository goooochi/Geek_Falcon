using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class RankingController : MonoBehaviour
{

    public GameObject SendFase;
    public GameObject RankingGetFase;

    public Text ScoreText;

    /// <summary>
    /// TitleId
    /// </summary>
    private const string TitleId = "Geek_Hawk";

    const string STATISTICS_NAME = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = "Test2ID", CreateAccount = true },
            result => Debug.Log("ログイン成功！"),
            error => Debug.Log("ログイン失敗"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //sednボタンを押した時の挙動
    public void ActiveFalseBeforeFase()
    {
        SendFase.SetActive(true);
        RankingGetFase.SetActive(true);

        //scoreを送信
        SubmitScore(TimeScript.instance.score);
        RequestLeaderBoard();

        Fade.instance.ranking = true;
    }

    void SubmitScore(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = STATISTICS_NAME,
                        Value = playerScore
                    }
                }
            },
            result =>
            {
                Debug.Log("スコア送信");
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }

    void RequestLeaderBoard()
    {
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = STATISTICS_NAME,
                StartPosition = 0,
                MaxResultsCount = 10
            },
            result =>
            {
                
                result.Leaderboard.ForEach(
                    x => 
                    ScoreText.text += $"\n順位 : {x.Position}, スコア : {x.StatValue}, 名前 : {x.DisplayName}, ID : {x.PlayFabId}"
                    );
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }
}
