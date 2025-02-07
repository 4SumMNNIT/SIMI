using System;
using UnityEngine;

public class CheaterDetection : MonoBehaviour
{

    ScoreCalculator scoreCalculator;
    void Start()
    {
        scoreCalculator = FindAnyObjectByType<ScoreCalculator>();
    }




    private void OnTriggerEnter(Collider other)
    {
   
        if (transform.parent.name.ToString() == "hand(Clone)")
        {

            string[] arr = { "Point (4)" , "Point (8)", "Point (12)", "Point (16)", "Point (20)" };

            bool found = Array.Exists(arr, name => name == other.gameObject.name);

            if (found) { 
            
                scoreCalculator.resetScore();
            }

        }
        else if (transform.parent.name.ToString() == "one_index_finger(Clone)")
        {


            string[] arr = { "Point (7)", "Point (8)" };

            bool found = Array.Exists(arr, name => name == other.gameObject.name);

            if (found)
            {

                scoreCalculator.resetScore();
            }
        }
        else if (transform.parent.name.ToString() == "two_fingers(Clone)")
        {
           
            string[] arr = { "Point (8)", "Point (12)" };

            bool found = Array.Exists(arr, name => name == other.gameObject.name);

            if (found)
            {

                scoreCalculator.resetScore();
            }
        }
        else if (transform.parent.name.ToString() == "three_fingers(Clone)")
        {

            string[] arr = { "Point (8)", "Point (12)", "Point (16)" };

            bool found = Array.Exists(arr, name => name == other.gameObject.name);

            if (found)
            {

                scoreCalculator.resetScore();
            }
        }
        else if (transform.parent.name.ToString() == "four_fingers(Clone)")
        {
    
            string[] arr = { "Point (8)", "Point (12)", "Point (16)", "Point (20)" };

            bool found = Array.Exists(arr, name => name == other.gameObject.name);

            if (found)
            {

                scoreCalculator.resetScore();
            }
        }
        
        
    }
}
