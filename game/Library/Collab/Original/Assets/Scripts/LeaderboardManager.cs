using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LeaderboardManager
{
    public static void populateList(GameStats.GameStats[] ranking)
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
        for (int i = ranking.Length; i < 10; i++)
        {
            string name = (i+1).ToString();
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

    public static List<GameStats.GameStats> getAllLocalGameStats()
    {
        var result = new List<GameStats.GameStats>();
        for (int i = 1; i <= 10; i++)
        {
            string name = i.ToString();
            GameObject row = GameObject.Find(name);
            GameObject nr = row.transform.GetChild(0).gameObject;
            GameObject playerName = row.transform.GetChild(1).gameObject;
            GameObject points = row.transform.GetChild(2).gameObject;
            GameObject level = row.transform.GetChild(3).gameObject;

            var newObj = new GameStats.GameStats();
            newObj.id = Int32.Parse(nr.GetComponent<Text>().text);
            newObj.playerName =  playerName.GetComponent<Text>().text;
            newObj.points = Int32.Parse(points.GetComponent<Text>().text);
            newObj.level = Int32.Parse(level.GetComponent<Text>().text);
            result.Add(newObj);
        }
        return result;
    }
}
