using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver_UI : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exiting the Game");
    }
}
