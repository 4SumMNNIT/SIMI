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
        menu, level, paused, over, error
    }
    public static GameState state;

    void Start()
    {
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
                state = GameState.error;
                break;
        }
        if (state == GameState.level){
            pauseMenu = GameObject.Find("PauseCanvas");
        }
    }

    void Update()
    {
        // if game is in level then check for udp data stability for pausing
        if (state == GameState.level && UDPManager.Instance.GetData() != previousValue)
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
        SceneManager.LoadScene(1);
    }

    public void PauseLevel()
    {
        // Debug.Log("Pause Called");
        state = GameState.paused;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeLevel()
    {
        // Debug.Log("Resume Called");
        state = GameState.level;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitLevel()
    {
        //enable mainmenu
        SceneManager.LoadScene(0);
    }

    public void ExitGame(){
        Application.Quit();
    }

    IEnumerator WaitForStability()
    {
        yield return new WaitForSeconds(delay);
        PauseLevel();
    }
}
