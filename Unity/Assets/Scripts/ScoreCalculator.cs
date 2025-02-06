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

        score.text = Time.time.ToString("0");

        //Debug.Log(Time.deltaTime);
    }
}
