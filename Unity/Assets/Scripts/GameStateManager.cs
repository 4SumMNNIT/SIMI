using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject MainMenuPanel;
    private string previousValue;
    private Coroutine checkRoutine;
    public float delay = 1.0f; // Reduced to 1 sec for hand detection pause

    public RectTransform cursor;
    public static bool isPaused;
    public static bool isMenu;
    public static bool isLevel;

    void Start()
    {
        // Show Main Menu at the beginning
        PausePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        isMenu=true;
        Time.timeScale = 0;
    }

    void Update()
    {
        // if game is in level then check for udp data stability for pausing
        if (isLevel && UDPManager.Instance.GetData() != previousValue)
        {
            previousValue = UDPManager.Instance.GetData();
            if (checkRoutine != null)
                StopCoroutine(checkRoutine);
            
            checkRoutine = StartCoroutine(WaitForStability());
        }
    }

    // start the game anew
    public void StartLevel()
    {
        // change the states, isLevel is handled by Update()
        isMenu = false;
        isPaused = false;
        isLevel = true;
        MainMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseLevel()
    {
        // Debug.Log("Pause Called");
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        isLevel = false;
    }
    public void ResumeLevel()
    {
        // Debug.Log("Resume Called");
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        isLevel = true;
    }
    public void ExitLevel()
    {
        //enable mainmenu
        MainMenuPanel.SetActive(true);
        isMenu=true;
        PausePanel.SetActive(false);
        Time.timeScale = 0;
        isPaused = false;
    }

    IEnumerator WaitForStability()
    {
        yield return new WaitForSeconds(delay);
        PauseLevel();
    }
}
