using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button btnPlay;
    public Button btnHighScores;
    public Button btnCredits;
    public Button btnBackToMainMenu;
    public Button btnExit;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(Play);
        btnHighScores.onClick.AddListener(HighScores);
        btnCredits.onClick.AddListener(Credits);
        btnBackToMainMenu.onClick.AddListener(BackToMainMenu);
        btnExit.onClick.AddListener(BackToMainMenu);
    }

    public void Play()
    {
        SceneManager.LoadScene(10);
        Debug.Log("asdf");
    }

    public void HighScores()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
