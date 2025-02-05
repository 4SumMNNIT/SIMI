using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public UDPReceive uDPReceive;
    public static bool isMenu;
    void Start()
    {
        isMenu=true;
        Cursor.visible = true; // Show cursor in Main Menu
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        MainPanel.SetActive(false);
        isMenu = false;
        Cursor.visible = false; // Hide cursor when starting the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
