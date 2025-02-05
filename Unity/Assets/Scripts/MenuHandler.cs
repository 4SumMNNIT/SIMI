using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject PausePanel;
    public GameObject MainMenuPanel;
    private string previousValue;
    private Coroutine checkRoutine;
    public float delay = 1.0f; // Reduced to 1 sec for hand detection pause

    public static bool isPaused;
    public static bool isMenu;

    void Start()
    {
        // Show Main Menu at the beginning
        MainMenuPanel.SetActive(true);
        isMenu=true;
        PausePanel.SetActive(false);
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (uDPReceive.data != previousValue)
        {
            previousValue = uDPReceive.data;
            if (checkRoutine != null)
                StopCoroutine(checkRoutine);
            
            checkRoutine = StartCoroutine(WaitForStability());
        }
    }

    public void PlayGame()
    {
        // Hide main menu and start the game
        isMenu=false;
        Cursor.visible = false;
        Time.timeScale = 1;
        MainMenuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Exit()
    {
        //enable mainmenu
        MainMenuPanel.SetActive(true);
        isMenu=true;
        PausePanel.SetActive(false);
        Time.timeScale = 0;
        isPaused = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator WaitForStability()
    {
        if(!isMenu){
        yield return new WaitForSeconds(delay);
        Debug.Log("Hand detected outside game - Pausing");
        Pause();}
    }
}
