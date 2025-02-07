using UnityEngine;

public class CheaterDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

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
            Debug.Log("sheesh");
        }
        else if (transform.parent.name.ToString() == "one_index_finger(Clone)")
        {
            Debug.Log("sheesh");

        }
        else if (transform.parent.name.ToString() == "two_fingers(Clone)")
        {
            Debug.Log("sheesh");
        }
        else if (transform.parent.name.ToString() == "three_fingers(Clone)")
        {
            Debug.Log("sheesh");
        }
        else if (transform.parent.name.ToString() == "four_fingers(Clone)")
        {
            Debug.Log("sheesh");
        }
        
        
    }
}
