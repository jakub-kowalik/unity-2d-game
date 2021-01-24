using GameStats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderboardsInMainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    GameObject levelChooseMenu;
    Dropdown dropdown;

    

    void Start()
    {
        levelChooseMenu = GameObject.Find("levelChooseMenu");
        dropdown = levelChooseMenu.transform.GetComponent<Dropdown>();
        /*dropdown.onValueChanged.AddListener(
            delegate { levelJustChosen(dropdown); }
            );*/
    }

    public void goToMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void levelJustChosen(Dropdown dropdown)
    {
        int lvl = chosenLevel(dropdown);
        Debug.Log("lvl just chosen = " + lvl);
        StartCoroutine(downloadRankingList(lvl));
    }

    public int chosenLevel(Dropdown dropdown)
    {
        int index = dropdown.value;
        string text = dropdown.options[index].text;
        return text[text.Length - 1] - '0';
    }

    public IEnumerator downloadRankingList(int lvl)
    {
        string uri = GlobalVariables.serverUri + "/GameStats/Level/" + lvl.ToString() + "/Get10Sorted";
        RequestHandler getTop10 = new RequestHandler(this, RequestHandler.getTop10Scores(uri) );
        yield return getTop10.coroutine;
        GameStats.GameStats[] stats = (GameStats.GameStats[])getTop10.result;
        LeaderboardManager.populateList(stats);
    }
}
