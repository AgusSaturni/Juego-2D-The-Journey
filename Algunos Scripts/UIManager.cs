using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);

    }

    public void Return()
    {
        Time.timeScale =1;
        optionsPanel.SetActive(false);
    }

    public void AnotherOpcionts()
    { 
    //sound graphics etc
    }

    public void GoMainMenu() 
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Exit() 
    {
        Application.Quit();

    }
    
}
