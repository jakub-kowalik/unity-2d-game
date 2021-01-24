using GameStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HTTPrequest
{
    void postGameStats(GameStats.GameStats gameStats)
    {
        gameStats.level = 3;
        gameStats.playerName = "Player1";
        gameStats.points = 100;
        string json = JsonUtility.ToJson(gameStats);
        Debug.Log(json);
    }


    public IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                string json = webRequest.downloadHandler.text;
                json = JsonHelper.fixJson(json);
                GameStats.GameStats[] ranking = JsonHelper.FromJson<GameStats.GameStats>(json);

                Debug.Log(":\nReceived: " + json);
            }
        }
    }

    public IEnumerator PostRequest(string uri, string body)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Put(uri, body))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(body + " " + webRequest.responseCode);
                Debug.Log(":\nReceived: " + webRequest.responseCode + " " + webRequest.downloadHandler.text);
            }
        }
    }
}
