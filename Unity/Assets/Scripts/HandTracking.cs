using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    void Update()
    {
        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        for (int i = 0; i < 21; i++)
        {
            float x = float.Parse(points[i * 3]);
            float y = float.Parse(points[i * 3 + 1]);
            float z = float.Parse(points[i * 3 + 2]) / 80;

            // Set hand position for all points
            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }

    }
}
