using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.ClientModels;



public class Login : MonoBehaviour
{
    /// <summary>
    /// TitleId
    /// </summary>
    private const string TitleId = "Geek_Hawk";

    const string STATISTICS_NAME = "HighScore";

    void Start()
    {
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = "Test2ID", CreateAccount = true },
            result => Debug.Log("ログイン成功！"),
            error => Debug.Log("ログイン失敗"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SubmitScore(500);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RequestLeaderBoard();
        }
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
                    x => Debug.Log(string.Format("{0}位:{1} スコア{2}", x.Position + 1, x.DisplayName, x.StatValue))
                    );
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }
}
