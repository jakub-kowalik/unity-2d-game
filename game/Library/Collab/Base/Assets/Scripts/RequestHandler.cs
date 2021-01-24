using GameStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestHandler
{
    public Coroutine coroutine { get; private set; }
    public object result;
    private IEnumerator target;
    public RequestHandler(MonoBehaviour owner, IEnumerator target)
    {
        this.target = target;
        this.coroutine = owner.StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while (target.MoveNext())
        {
            result = target.Current;
            yield return result;
        }
    }



    public static IEnumerator postYourScore(string uri, string body)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, body))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
                yield return webRequest.error;
            }
            else
            {
                Debug.Log(body + " " + webRequest.responseCode);
                Debug.Log(":\nReceived: " + webRequest.responseCode + " " + webRequest.downloadHandler.text);
                yield return webRequest.downloadHandler.text;
            }
        }
    }

    public static IEnumerator getTop10Scores(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
                yield return null;
            }
            else
            {
                string json = webRequest.downloadHandler.text;
                Debug.Log(":\nReceived: " + json);
                json = JsonHelper.fixJson(json);
                GameStats.GameStats[] ranking = JsonHelper.FromJson<GameStats.GameStats>(json);
                yield return ranking;

                LeaderboardManager.populateList(ranking);
            }
        }
    }
}
