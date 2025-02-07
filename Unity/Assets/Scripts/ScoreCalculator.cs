// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// public class ScoreCalculator : MonoBehaviour
// {

//     // public Text score;
//     public TextMeshProUGUI score;
//     private int maxScore = 0; // store highest score

//     int counter = 0;

//     private float lastUpdateTime = 0f;


//     void Update()
//     {
        

//         if (Time.time - lastUpdateTime >= 1f) // Check if 1 second has passed
//         {
//             lastUpdateTime = Time.time; // Update last recorded time
//             counter++; // Increase score
//             score.text =  counter.ToString(); // Update UI text
//         }

//         //Debug.Log(Time.deltaTime);
//     }


//     //For punishing cheater
//     public void resetScore()
//     {
//         if (counter > maxScore)  // Update maxScore before resetting
//         {
//             maxScore = counter;
//         }
//         counter = 0;

//         score.text = counter.ToString("0");
//     }

//     public int getScore(){
//         return counter;
//     }

//     public int getMaxScore() // Function to get the highest score
//     {
//         return maxScore;
//     }
// }

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreCalculator : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverCanvas; // Game Over UI

    public Image[] lifeIcons; // Array to store heart images

    private int counter = 0;
    private int maxScore = 0;
    private int lives = 3; // Player starts with 3 lives
    private float lastUpdateTime = 0f;
    private float lastLifeLostTime = 0f;
private float lifeLossCooldown = 1.0f; // 1 second cooldown

    void Start()
    {
        UpdateLivesUI();
        // gameOverCanvas.SetActive(false); // Hide Game Over screen initially
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

    public void DecreaseLife() // Call this function when the player cheats
    {
        if (counter > maxScore)
        {
            maxScore = counter;
        }

        lives--; // Decrease life
        Debug.Log("Lives: " + lives);
        UpdateLivesUI(); 

        if (lives <= 0)
        {
            GameOver(); // Stop the game
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < lives; // Enable hearts based on remaining lives
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver"); // Load Game Over scene
        Time.timeScale = 0; // Pause the game
        // gameOverCanvas.SetActive(true); // Show Game Over screen
    }

    public int getScore()
    {
        return counter;
    }

    public int getMaxScore()
    {
        return maxScore;
    }

    //For punishing cheater
        // public void resetScore()
        // {
        //     if (counter > maxScore)  // Update maxScore before resetting
        //     {
        //         maxScore = counter;
        //     }
        //     counter = 0;
        //     lives--; // Decrease life
        //     Debug.Log("Lives: " + lives);
        //     UpdateLivesUI(); 

        //     if (lives <= 0)
        //     {
        //         GameOver(); // Stop the game
        //     }
        //     scoreText.text = counter.ToString("0");
        // }

    public void resetScore()
{
    if (Time.time - lastLifeLostTime < lifeLossCooldown) return; // Prevent multiple deductions

    lastLifeLostTime = Time.time;
    
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
