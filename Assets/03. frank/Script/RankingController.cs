using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class RankingController : MonoBehaviour
{

    public GameObject SendFase;
    public GameObject RankingGetFase;

    [SerializeField] public InputField userName;
    public Text ScoreText;

    [SerializeField] Text[] userNamesText = new Text[5];
    [SerializeField] Text[] userScoresText = new Text[5];


    /// <summary>
    /// TitleId
    /// </summary>
    [SerializeField] const string TitleId = "Geek_Hawk";

    const string STATISTICS_NAME = "HighScore";


    // Start is called before the first frame update
    void Start()
    {

        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = TitleId;
        }

        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = CreateNewPlayerId(), CreateAccount = true },
            result => Debug.Log("ログイン成功！"),
            error => Debug.Log("ログイン失敗"));

        Fade.instance.ranking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //sednボタンを押した時の挙動
    public void ActiveFalseBeforeFase()
    {
        SendFase.SetActive(false);
        RankingGetFase.SetActive(true);

        //scoreを送信
        SubmitScore(-1 * 250);
        SetUserName(userName.text);
        RequestLeaderBoard();

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

    private void SetUserName(string userName)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = userName
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnSuccess, OnError);

        void OnSuccess(UpdateUserTitleDisplayNameResult result)
        {
            Debug.Log("success!");
        }

        void OnError(PlayFabError error)
        {
            Debug.Log($"{error.Error}");
        }
    }

    void RequestLeaderBoard()
    {
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = STATISTICS_NAME,
                StartPosition = 0,
                MaxResultsCount = 5
            },
            result =>
            {
                foreach (var item in result.Leaderboard)
                {
                    // Positionは順位です。0から始まるので+1して表示しています。
                    Debug.Log($"{item.Position + 1}位: {item.DisplayName} - {item.StatValue}");

                    userNamesText[item.Position].text = item.DisplayName;

                    userScoresText[item.Position].text = (-1 * item.StatValue).ToString();
                }

            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }

    /// <summary>
    /// PlayerIdの新規作成
    /// </summary>
    /// <returns></returns>
    private string CreateNewPlayerId()
    {
        return Guid.NewGuid().ToString("N");
    }
}
