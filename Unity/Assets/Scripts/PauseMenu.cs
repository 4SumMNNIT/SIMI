using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using UnityEngine.Experimental.GlobalIllumination;

public class PauseMenu : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject PausePanel;
    private string previousValue;
    private Coroutine checkRoutine;
    public float delay = 1.5f;

    public static bool isPaused;

    void Start()
    {
        PausePanel.SetActive(false);
        previousValue = uDPReceive.data;
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

    public void Pause(){
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Continue(){
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    IEnumerator WaitForStability()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Pause");
        Pause();
    }
}
