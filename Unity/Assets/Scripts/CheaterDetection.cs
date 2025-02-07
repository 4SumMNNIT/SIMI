using UnityEngine;
using UnityEngine.UI;

public class CheaterDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    ScoreCalculator scoreCalculator;
    void Start()
    {
        scoreCalculator = FindAnyObjectByType<ScoreCalculator>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}



    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(transform.parent.name);
        //string wall = "hand(Clone)";
        
        if (transform.parent.name.ToString() == "hand(Clone)")
        {
           
            if(other.gameObject.name== "Point (4)") { 
            
                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (8)")
            {
                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (12)")
            {
                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (16)")
            {
                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (20)")
            {
                scoreCalculator.resetScore();
            }
        }
        else if (transform.parent.name.ToString() == "one_index_finger(Clone)")
        {

            if (other.gameObject.name == "Point (8)")
            {

                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (7)")
            {

                scoreCalculator.resetScore();
            }
        }
        else if (transform.parent.name.ToString() == "two_fingers(Clone)")
        {
            if (other.gameObject.name == "Point (8)")
            {

                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (12)")
            {

                scoreCalculator.resetScore();
            }
        }
        else if (transform.parent.name.ToString() == "three_fingers(Clone)")
        {
            if (other.gameObject.name == "Point (8)")
            {

                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (12)")
            {

                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (16)")
            {

                scoreCalculator.resetScore();
            }
        }
        else if (transform.parent.name.ToString() == "four_fingers(Clone)")
        {
            if (other.gameObject.name == "Point (8)")
            {

                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (12)")
            {

                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (16)")
            {

                scoreCalculator.resetScore();
            }
            if (other.gameObject.name == "Point (20)")
            {

                scoreCalculator.resetScore();
            }
        }
        
        
    }
}
