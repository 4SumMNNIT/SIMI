using System;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public GameObject[] handPoints;

    // boundry limits
    private float x_min_boundary = -5.2f; 
    private float x_max_boundary = 5.2f;  
    private float y_min_boundary = 0f;    
    private float y_max_boundary = 12f;
    void Update()
    {
        if (GameManager.state == GameManager.GameState.level || GameManager.state == GameManager.GameState.free)
        {
            string[] points = UDPManager.Instance.GetDataPoints();

            for (int i = 0; i < 21; i++)
            {
                float x = float.Parse(points[i * 3]);
                float y = float.Parse(points[i * 3 + 1]);
                float z = float.Parse(points[i * 3 + 2]) / 80;

                if (GameManager.state == GameManager.GameState.level){
                    // force boundry limits on hand
                    x = Math.Max(x_min_boundary, Math.Min(x, x_max_boundary));
                    y = Math.Max(y_min_boundary, Math.Min(y, y_max_boundary));
                }

                // Set hand position for all points
                handPoints[i].transform.localPosition = new Vector3(x, y, z);
            }
        }
    }
}
