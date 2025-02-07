using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Restart game by loading previous scene
    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        SceneManager.LoadScene("Menu");
        // Application.Quit();
    }
}
