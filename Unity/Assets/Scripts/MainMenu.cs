using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    //Start Game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Exit game ONLY WORKS ON BUILD
    public void ExitGame()
    {
        Application.Quit();
    }
}
