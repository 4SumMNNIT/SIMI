using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FreePlay : MonoBehaviour
{
    private string previousValue;
    private Coroutine checkRoutine;
    public float delay = 1.5f;

    void Start()
    {

    }

    void Update()
    {
        // if game is in level then check for udp data stability for pausing
        if (GameManager.state == GameManager.GameState.free && UDPManager.Instance.GetData() != previousValue)
        {
            previousValue = UDPManager.Instance.GetData();
            if (checkRoutine != null)
                StopCoroutine(checkRoutine);
            checkRoutine = StartCoroutine(WaitForStability());
        }
    }

    public void ExitFreePlay()
    {
        GameManager.state = GameManager.GameState.menu;
        SceneManager.LoadScene(0);
    }

    IEnumerator WaitForStability()
    {
        yield return new WaitForSeconds(delay);
        ExitFreePlay();
    }
}
