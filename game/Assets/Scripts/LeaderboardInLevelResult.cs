using GameStats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LeaderboardInLevelResult : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(downloadRankingList(GlobalVariables.Level));
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public IEnumerator downloadRankingList(int lvl)
    {
        string uri = GlobalVariables.serverUri + "/GameStats/Level/" +lvl.ToString() +"/Get10Sorted";
        RequestHandler getTop10 = new RequestHandler(this, RequestHandler.getTop10Scores(uri));
        yield return getTop10.coroutine;
        GameStats.GameStats[] stats = (GameStats.GameStats[])getTop10.result;
        LeaderboardManager.populateList(stats);
    }
}
