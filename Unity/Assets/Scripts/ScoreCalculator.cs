using UnityEngine;
using UnityEngine.UI;
public class ScoreCalculator : MonoBehaviour
{

    public Text score;
    int counter = 0;

    private float lastUpdateTime = 0f;


    void Update()
    {
        

        if (Time.time - lastUpdateTime >= 1f) // Check if 1 second has passed
        {
            lastUpdateTime = Time.time; // Update last recorded time
            counter++; // Increase score
            score.text =  counter.ToString(); // Update UI text
        }



        //Debug.Log(Time.deltaTime);
    }


    //For punishing cheater
    public void resetScore()
    {
        counter = 0;

        score.text = counter.ToString("0");
    }
}
