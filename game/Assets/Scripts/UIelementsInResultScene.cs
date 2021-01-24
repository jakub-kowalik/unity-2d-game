using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameStats;
using UnityEngine.Networking;

public class UIelementsInResultScene : MonoBehaviour
{
    Text score;
    InputField playerNameInputField;
    Button quitButton;
    Button nextLevelButton;
    Button restartLevelButton;
    Button saveScoreButton;


    void Awake()
    {
        score = GameObject.Find("score").GetComponent<Text>();
        score.text = "YOUR SCORE: " + GlobalVariables.Score;
        playerNameInputField = GameObject.Find("playerNameInputField").GetComponent<InputField>();
        playerNameInputField.text = GlobalVariables.PlayerName;

        quitButton = GameObject.Find("quitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(() => toMainMenu());

        restartLevelButton = GameObject.Find("restartLevelButton").GetComponent<Button>();
        restartLevelButton.onClick.AddListener(() => restartLevel());

        saveScoreButton = GameObject.Find("saveScoreButton").GetComponent<Button>();
        saveScoreButton.onClick.AddListener(() => saveScore());

        nextLevelButton = GameObject.Find("nextLevelButton").GetComponent<Button>();
        nextLevelButton.onClick.AddListener(() => goToNextLevel());
        nextLevelButton.interactable = (GlobalVariables.Level == GlobalVariables.amountOfLevels) ? false : true;
        
    }
    public void saveScore()
    {
        saveScoreButton.interactable = false;
        StartCoroutine(postYourScore());
    }
    public IEnumerator postYourScore()
    {
        GlobalVariables.PlayerName = playerNameInputField.text;

        GameStats.GameStats gamestats = new GameStats.GameStats();
        gamestats.level = GlobalVariables.Level;
        gamestats.playerName = GlobalVariables.PlayerName;
        gamestats.points = GlobalVariables.Score;
        string json = JsonUtility.ToJson(gamestats);

        updateTableLocally(gamestats);
        RequestHandler postScore = new RequestHandler(this, RequestHandler.postYourScore(GlobalVariables.serverUri + "/GameStats/Create", json));
        yield return postScore.coroutine; 

       
    }

    public void updateTableLocally(GameStats.GameStats statsToAdd)
    {
        var allStats = LeaderboardManager.getAllLocalGameStats();

        if (allStats.Count == 0) allStats.Insert(0, statsToAdd);
        else
        {
            for (int i = 0; i < allStats.Count; i++)
            {
                if (allStats[i].points <= statsToAdd.points)
                {
                    allStats.Insert(i, statsToAdd);
                    allStats.RemoveAt(allStats.Count - 1);
                    break;
                }
            }
        }
        LeaderboardManager.populateList(allStats.ToArray());
    }

    public void restartLevel()
    {
        GlobalVariables.resetValues();
        SceneManager.LoadSceneAsync(GlobalVariables.Level);
    }

    public void goToNextLevel()
    {
        GlobalVariables.resetValues();
        GlobalVariables.Level += 1;
        SceneManager.LoadSceneAsync(GlobalVariables.Level);
    }

    public void toMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
