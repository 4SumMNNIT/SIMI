using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    public GameObject cursor;
    public RectTransform rectTransform;
    private Dictionary<string, float> coordinateMap = new Dictionary<string, float>
    {
        { "udpInputXMin", -10f },
        { "udpInputXMax", 10f },
        { "udpInputYMin", -0.7f },
        { "udpInputYMax", 10.7f },
        { "gameXMin", -960f },
        { "gameXMax", 960f },
        { "gameYMin", -540f },
        { "gameYMax", 540f }
    };
    public static bool isClick = false;
    public float errorMargin = 0.8f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // if (GameManager.state == "level"){
        //     cursor.SetActive(false);
        // }
    }

    void Update()
    {
        if (GameManager.state != GameManager.GameState.level)
        {
            // move the cursor
            // cursor.SetActive(true);
            MoveCursor(UDPManager.Instance.GetDataPoints());
            // click handling
            CheckForClick(UDPManager.Instance.GetDataPoints());
        }
        else
        {
            // cursor.SetActive(false);
        }
    }

    void MoveCursor(string[] points)
    {
        float inputX = float.Parse(points[8 * 3]);
        float inputY = float.Parse(points[8 * 3 + 1]);
        // Debug.Log(""+inputX+" "+inputY);
        float mappedX = MapRange(inputX, coordinateMap["udpInputXMin"],
        coordinateMap["udpInputXMax"], coordinateMap["gameXMin"], coordinateMap["gameXMax"]);
        float mappedY = MapRange(inputY, coordinateMap["udpInputYMin"],
        coordinateMap["udpInputYMax"], coordinateMap["gameYMin"], coordinateMap["gameYMax"]);
        // Debug.Log(""+mappedX+" "+mappedY);
        rectTransform.localPosition = new Vector2(mappedX, mappedY);
    }

    void CheckForClick(string[] points)
    {
        Vector2 middleTip = new Vector2(float.Parse(points[12 * 3]), float.Parse(points[12 * 3 + 1]));
        Vector2 thumbTip = new Vector2(float.Parse(points[4 * 3]), float.Parse(points[4 * 3 + 1]));
        // Debug.Log("thumb: " + thumbTip);
        // Debug.Log("middle: " + middleTip);
        float distance = Vector2.Distance(middleTip, thumbTip);
        // Debug.Log(distance);
        if (distance < errorMargin && !isClick)
        {
            // Debug.Log("Click detected!");
            isClick = true;

        }
        else if (distance > errorMargin)
        {
            isClick = false;
        }
    }

    float MapRange(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        float normalizedValue = Mathf.InverseLerp(fromMin, fromMax, value);
        return Mathf.Lerp(toMin, toMax, normalizedValue);
    }
}
