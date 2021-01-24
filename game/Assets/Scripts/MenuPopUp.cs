using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPopUp : MonoBehaviour
{
    public Button backToGameButton;
    public Button goToOptionsPopUPButton;
    GameObject optionsMenu;
    public Button openMenuPopUpButton;
    public Button gotToMainMenuButton;


    void Start()
    {
        optionsMenu = GameObject.Find("optionsPopUp");

        backToGameButton = GameObject.Find("resumeGameButton").GetComponent<Button>();
        backToGameButton.onClick.AddListener(() => CloseMenu());

        goToOptionsPopUPButton = GameObject.Find("optionsButton").GetComponent<Button>();
        goToOptionsPopUPButton.onClick.AddListener(() => openOptions());

        gotToMainMenuButton = GameObject.Find("backToMainMenuButton").GetComponent<Button>();
        gotToMainMenuButton.onClick.AddListener(() => goToMainMenu());

        openMenuPopUpButton = GameObject.Find("openMenuPopUpButton").GetComponent<Button>();
        openMenuPopUpButton.onClick.AddListener(() => OpenMenu());
        CloseMenu();
    }

    private void goToMainMenu()
    {
        SceneManager.LoadScene(0); // mainmenu
    }

    private void openOptions()
    {
        gameObject.SetActive(false);
        optionsMenu.SetActive(true);
        openMenuPopUpButton.interactable = false;
    }
    public void CloseMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        GlobalVariables.isMenuOpen = false;
    }
    private void OpenMenu()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        GlobalVariables.isMenuOpen = true;
    }
}
