using UnityEngine;
using UnityEngine.UIElements;

public class CursorHandler : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject cursor;
    public RectTransform rectTransform;

    private float udpInputXMin = -10f;
    private float udpInputXMax = 10f;
    private float udpInputYMin = -0.7f;
    private float udpInputYMax = 10.7f;
    private float gameXMin = -960f;
    private float gameXMax = 960f;
    private float gameYMin = -540f;
    private float gameYMax = 540f;
    public static bool isClick = false;
    public float errorMargin = 0.8f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!GameStateManager.isMenu || !GameStateManager.isPaused){
            cursor.SetActive(false);
        }
    }

    void Update()
    {
        if (GameStateManager.isMenu || GameStateManager.isPaused)
        {
            // move the cursor
            cursor.SetActive(true);
            MoveCursor(UDPManager.GetDataPoints());
            // click handling
            CheckForClick(UDPManager.GetDataPoints());
        }else{
            cursor.SetActive(false);
        }

    }

    void MoveCursor(string[] points){
        float inputX = float.Parse(points[8 * 3]);
        float inputY = float.Parse(points[8 * 3 + 1]);
        // Debug.Log(""+inputX+" "+inputY);
        float mappedX = MapRange(inputX, udpInputXMin, udpInputXMax, gameXMin, gameXMax);
        float mappedY = MapRange(inputY, udpInputYMin, udpInputYMax, gameYMin, gameYMax);
        // Debug.Log(""+mappedX+" "+mappedY);
        rectTransform.localPosition = new Vector2(mappedX, mappedY);
    }

    void CheckForClick(string[] points){
        Vector2 middleTip = new Vector2(float.Parse(points[12 * 3]), float.Parse(points[12 * 3 + 1]));
        Vector2 thumbTip = new Vector2(float.Parse(points[4 * 3]), float.Parse(points[4 * 3 + 1]));
        // Debug.Log("thumb: " + thumbTip);
        // Debug.Log("middle: " + middleTip);
        float distance = Vector2.Distance(middleTip, thumbTip);
        // Debug.Log(distance);
        if (distance < errorMargin && !isClick){
            // Debug.Log("Click detected!");
            isClick = true;
            
        }else if(distance > errorMargin){
            isClick = false;
        }
    }
    
    bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];

        rect1.GetWorldCorners(corners1);
        rect2.GetWorldCorners(corners2);

        Rect rectA = new Rect(corners1[0].x, corners1[0].y, corners1[2].x - corners1[0].x, corners1[2].y - corners1[0].y);
        Rect rectB = new Rect(corners2[0].x, corners2[0].y, corners2[2].x - corners2[0].x, corners2[2].y - corners2[0].y);

        return rectA.Overlaps(rectB);
    }
    float MapRange(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        float normalizedValue = Mathf.InverseLerp(fromMin, fromMax, value);
        return Mathf.Lerp(toMin, toMax, normalizedValue);
    }
}
