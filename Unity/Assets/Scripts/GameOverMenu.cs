using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverMenu : MonoBehaviour
{
    // Restart game by loading previous scene

    public TextMeshProUGUI finalScoreText; // Reference to TMP text

    public void Start()
    {
        int score = PlayerPrefs.GetInt("FinalScore", 0); // Get saved score
        Debug.Log("Final Score: " + score);
        finalScoreText.text =  score.ToString(); // Display score
    }
    // public void Start()
    // {
    //     int score = PlayerPrefs.GetInt("FinalScore");
    //     Debug.Log("Final Score: " + score);
    // }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        SceneManager.LoadScene("Menu");
        // Application.Quit();
    }
}
