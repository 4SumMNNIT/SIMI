using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        // Debug.Log("Restart Button Clicked!"); 

        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        if (previousSceneIndex >= 0) 
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogError("No previous scene found!");
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exit Button Clicked!");
        Application.Quit();
    }

}
