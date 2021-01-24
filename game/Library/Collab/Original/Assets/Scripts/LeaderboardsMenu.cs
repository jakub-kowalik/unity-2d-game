using GameStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderboardsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    GameObject levelChooseMenu;
    Dropdown dropdown;

    

    void Start()
    {
        levelChooseMenu = GameObject.Find("levelChooseMenu");
        mainMenu = GameObject.Find("mainMenu");
        dropdown = levelChooseMenu.transform.GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(
            delegate { levelJustChosen(dropdown); }
            );
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void goToMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void levelJustChosen(Dropdown dropdown)
    {
        int lvl = chosenLevel(dropdown);
        Debug.Log("Level just chosen: " + lvl);
        downloadRankingList(lvl);
    }

    public int chosenLevel(Dropdown dropdown)
    {
        int index = dropdown.value;
        string text = dropdown.options[index].text;
        return text[text.Length - 1] - '0';
    }

    public void downloadRankingList(int lvl)
    {
        StartCoroutine(GetRequest("https://localhost:44327/GameStats/GetAllSorted")); // supposed to take lvl in consideration later
    }



    public IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                string json = webRequest.downloadHandler.text;
                Debug.Log(":\nReceived: " + json);
                json = JsonHelper.fixJson(json);
                GameStats.GameStats[] ranking = JsonHelper.FromJson<GameStats.GameStats>(json);

                populateList(ranking);
                clearRestOfTheList(ranking.Length);
            }
        }
    }
    public void populateList(GameStats.GameStats[] ranking)
    {
        for (int i = 0; i < ranking.Length; i++)
        {
            string name = (i + 1).ToString();
            GameObject row = GameObject.Find(name);
            GameObject nr = row.transform.GetChild(0).gameObject;
            GameObject playerName = row.transform.GetChild(1).gameObject;
            GameObject points = row.transform.GetChild(2).gameObject;
            GameObject level = row.transform.GetChild(3).gameObject;


            nr.GetComponent<Text>().text = name;
            playerName.GetComponent<Text>().text = ranking[i].playerName;
            points.GetComponent<Text>().text = (ranking[i].points).ToString();
            level.GetComponent<Text>().text = (ranking[i].level).ToString();

        }
    }

    public void clearRestOfTheList(int firstIndex)
    {
        for (int i = firstIndex; i <= 10; i++)
        {
            string name = i.ToString();
            GameObject row = GameObject.Find(name);
            GameObject nr = row.transform.GetChild(0).gameObject;
            GameObject playerName = row.transform.GetChild(1).gameObject;
            GameObject points = row.transform.GetChild(2).gameObject;
            GameObject level = row.transform.GetChild(3).gameObject;


            nr.GetComponent<Text>().text = name;
            playerName.GetComponent<Text>().text = "-";
            points.GetComponent<Text>().text = "-";
            level.GetComponent<Text>().text = "-";
        }
    }

}
