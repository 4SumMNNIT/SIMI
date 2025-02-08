using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreCalculator : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public Image[] lifeIcons; // Array to store life

    private int counter = 0;
    private int maxScore = 0;
    private int lives = 3; 
    private float lastUpdateTime = 0f;
    private float lastLifeLostTime = 0f;
private float lifeLossCooldown = 1.0f; // 1 second cooldown

    void Start()
    {
        UpdateLivesUI();
    }

    void Update()
    {
        if (Time.time - lastUpdateTime >= 1f)
        {
            lastUpdateTime = Time.time;
            counter++;
            scoreText.text = counter.ToString();
        }
    }


    private void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < lives; 
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver"); // Load Game Over scene
        Time.timeScale = 0; // Pause the game
    }

    public int getScore()
    {
        return counter;
    }

    public int getMaxScore()
    {
        return maxScore;
    }

    public void resetScore()
{
    if (Time.time - lastLifeLostTime < lifeLossCooldown) return; // multiple deductions

    lastLifeLostTime = Time.time;

    
    //Camera Shake



    lives--; 
    Debug.Log("Lives: " + lives);
    UpdateLivesUI(); 

    if (lives <= 0)
    {
        GameOver();
    }
    // scoreText.text = counter.ToString("0");
}
}
