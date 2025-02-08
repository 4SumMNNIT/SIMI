using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject pauseMenu;
    private string previousValue;
    private Coroutine checkRoutine;
    public float delay = 1.0f; // Reduced to 1 sec for hand detection pause
    public enum GameState{
        menu, level, paused, over, free
    }
    public static GameState state;

    void Start()
    {
        setState();
        if (state == GameState.level){
            pauseMenu = GameObject.Find("PauseCanvas");
        }
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // if game is in level then check for udp data stability for pausing
        if (state == GameState.level && UDPManager.Instance.GetData() != previousValue)
        {
            Debug.Log("In Game");
            previousValue = UDPManager.Instance.GetData();
            if (checkRoutine != null)
                StopCoroutine(checkRoutine);
            checkRoutine = StartCoroutine(WaitForStability());
        }
    }

    private void setState(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        switch(scene){
            case 0:
                state = GameState.menu;
                break;
            case 1:
                state = GameState.level;
                break;
            case 2:
                state = GameState.over;
                break;
            default:
                state = GameState.free;
                break;
        }
    }

    // start the game anew
    public void StartLevel()
    {
        Time.timeScale = 1;
        CursorHandler.isClick = false;
        SceneManager.LoadScene(1);
    }

    public void PauseLevel()
    {
        Debug.Log("Pause Called");
        CursorHandler.isClick = false;
        state = GameState.paused;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeLevel()
    {
        Debug.Log("Resume Called");
        CursorHandler.isClick = false;
        state = GameState.level;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitLevel()
    {
        //enable mainmenu
        CursorHandler.isClick = false;
        SceneManager.LoadScene(0);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void FreePlayGame(){
        CursorHandler.isClick = false;
        state = GameState.free;
        SceneManager.LoadScene(3);
    }

    IEnumerator WaitForStability()
    {
        yield return new WaitForSeconds(delay);
        PauseLevel();
    }
}
