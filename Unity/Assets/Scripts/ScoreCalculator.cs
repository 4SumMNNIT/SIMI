using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCalculator : MonoBehaviour
{

    public Text score;
    
    void Update()
    {
        //number= number + (int)Time.deltaTime;
        //score.text= number.ToString();

        // dont show score if score is zero
        if (Time.time > 0 && !GameStateManager.isPaused) {
            score.enabled = true;
        }
        else {
            score.enabled = false;
        }

        // show score
        score.text = Time.time.ToString("0");


        //Debug.Log(Time.deltaTime);
    }
}
