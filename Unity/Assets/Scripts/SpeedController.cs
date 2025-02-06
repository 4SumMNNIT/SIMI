using UnityEngine;

public class SpeedController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 2f;
    public float elaspedTime = 0f;
   
    public float Controller()
    {
        elaspedTime += Time.deltaTime;

        int time = Mathf.RoundToInt(elaspedTime);

        if (time == 10)
        {
            moveSpeed += 5;
            elaspedTime = 0;

        }
        // Debug.Log("moveSpeed");

        return moveSpeed;
        
    }
}
