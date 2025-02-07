using UnityEngine;
using UnityEngine.SceneManagement;
public class BoundaryHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boundary Hit");
        SceneManager.LoadScene("GameOver");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
