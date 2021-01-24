using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopUp : MonoBehaviour
{
    public Button goBackToMenuButton;
    public GameObject menu;
    public Button openMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        goBackToMenuButton.onClick.AddListener(() => goBackToMenu());
        gameObject.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
    }

    public void goBackToMenu()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
        openMenuButton.interactable = true;
    }
}
