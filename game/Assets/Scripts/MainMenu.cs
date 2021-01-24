using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject leaderboard;

    // Start is called before the first frame update
    void Start()
    {
        leaderboard = GameObject.Find("leaderboard");
        leaderboard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToLeaderboard()
    {
        leaderboard.SetActive(true);
        gameObject.SetActive(false);
    }
    public void StartGame()
    {
        GlobalVariables.resetValues();
        SceneManager.LoadSceneAsync("Level_1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
