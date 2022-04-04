using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject Credits;

    private void Start()
    {
        this.Credits.SetActive(false);
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("GameContentScence");
        Time.timeScale = 1f;
    }

    public void OnExitGame()
    {
        Application.Quit();
    }

    
    public void OnShowCredits()
    {
        this.Credits.SetActive(true);
    }
    public void OnHideCredits()
    {
        this.Credits.SetActive(false);
    }
}
