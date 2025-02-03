using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Restart game by loading previous scene
    public void RestartGame()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex >= 0) 
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else{
            Debug.Log("No previous scene to load.");
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
