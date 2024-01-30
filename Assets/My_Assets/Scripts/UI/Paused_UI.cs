using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Paused_UI : MonoBehaviour
{
    public GameObject Pause;
    private bool IsPaused;

    private void Start()
    {
        Pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PausedGame();
            }
    }
    public void PausedGame()
    {
        Pause.SetActive(true);
        Time.timeScale = 1f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exiting The Game");
    }
}
