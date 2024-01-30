using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Meun_UI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level_0");
    }
    public void OpenOption()
    {

    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exiting the Game");
    }
}


