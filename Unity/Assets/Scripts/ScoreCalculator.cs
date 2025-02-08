using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class ScoreCalculator : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
     public TextMeshProUGUI loseText;
    private ScoreCalculator scoreCalculator;
    public float delayBeforeGameOver = 1f; // Delay before scene transition

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
        loseText.gameObject.SetActive(false);
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

    public void GameOver()
    {
        // SceneManager.LoadScene("GameOver"); // Load Game Over scene
        // Time.timeScale = 0; // Pause the game

        Time.timeScale = 0f;
        loseText.gameObject.SetActive(true);
        // Stop the background music
        GameObject bgMusicObject = GameObject.FindGameObjectWithTag("Bgsound");
        if (bgMusicObject != null)
        {
            AudioSource bgMusic = bgMusicObject.GetComponent<AudioSource>();
            bgMusic.Stop();
        }

        // Play the collision sound
        GameObject hitSoundObject = GameObject.FindGameObjectWithTag("Hitsound");
        if (hitSoundObject != null)
        {
            AudioSource hitSound = hitSoundObject.GetComponent<AudioSource>();
            hitSound.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource with tag 'Hitsound' found!");
        }

        int score = getScore();
            PlayerPrefs.SetInt("FinalScore", score); // Save score before switching scene
            PlayerPrefs.Save();
        // Wait and then load GameOver scene
        StartCoroutine(LoadGameOverScene());
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

        lives--;
        Debug.Log("Lives: " + lives);
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
        // scoreText.text = counter.ToString("0");
    }
    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSecondsRealtime(delayBeforeGameOver);
        SceneManager.LoadScene("GameOver");
    }
}
