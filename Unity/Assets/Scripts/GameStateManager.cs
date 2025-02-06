using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject PausePanel;
    public GameObject MainMenuPanel;
    public GameObject GameOverPanel; // NEW: Game Over Menu

    private string previousValue;
    private Coroutine checkRoutine;
    public float delay = 1.0f; // Reduced to 1 sec for hand detection pause

    public RectTransform cursor;
    public static bool isPaused;
    public static bool isMenu;
    public static bool isLevel;
    public static bool isGameOver; // NEW: Game Over State

    void Start()
    {
        // Show Main Menu at the beginning
        PausePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        GameOverPanel.SetActive(false); // NEW: Ensure it's hidden at start

        isMenu = true;
        isGameOver = false;
        Time.timeScale = 0;
    }

    void Update()
    {
        // If the game is in level, check for UDP data stability for pausing
        if (isLevel && uDPReceive.data != previousValue)
        {
            previousValue = uDPReceive.data;
            if (checkRoutine != null)
                StopCoroutine(checkRoutine);
            
            checkRoutine = StartCoroutine(WaitForStability());
        }

        // NEW: Game Over Simulation (Example Condition)
        if (isLevel && CheckGameOverCondition()) 
        {
            PausePanel.SetActive(false);
            GameOverLevel();
        }
    }

    public void StartLevel()
    {
        isMenu = false;
        isPaused = false;
        isLevel = true;
        isGameOver = false; // Reset Game Over state
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseLevel()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        isLevel = false;
    }

    public void ResumeLevel()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        isLevel = true;
    }

    public void ExitLevel()
    {
        MainMenuPanel.SetActive(true);
        isMenu = true;
        isPaused = false;
        isGameOver = false; // Reset Game Over state
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        Time.timeScale = 0;
    }

    // NEW: Game Over Function
    public void GameOverLevel()
    {
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;
        isLevel = false;
        isPaused = false;
    }

    public void RestartLevel()
    {
        MainMenuPanel.SetActive(true);
        isMenu = true;
        isPaused = false;
        isGameOver = false; // Reset Game Over state
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        Time.timeScale = 0;
    }
    IEnumerator WaitForStability()
    {
        yield return new WaitForSeconds(delay);
        PauseLevel();
    }

    // NEW: Sample Game Over Condition
    private bool CheckGameOverCondition()
    {
        return BoundaryHit.isover; // Replace with actual game over logic (e.g., health <= 0)
    }
}
