using UnityEngine;

public class BoundaryHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool isover;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boundary Hit");
        isover = true;
        // GameStateManager.GameOverLevel();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
