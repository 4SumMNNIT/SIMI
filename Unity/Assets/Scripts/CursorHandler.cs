using UnityEngine;

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

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!MenuHandler.isMenu || !MenuHandler.isPaused){
            // Debug.Log("CursorHandler Start");
            // Debug.Log(MenuHandler.isMenu);
            // Debug.Log(MenuHandler.isPaused);
            cursor.SetActive(false);
        }
    }


    void Update()
    {
        if (MenuHandler.isMenu || MenuHandler.isPaused)
        {
            cursor.SetActive(true);
            string data = udpReceive.data;
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            string[] points = data.Split(',');
            float inputX = float.Parse(points[8 * 3]);
            float inputY = float.Parse(points[8 * 3 + 1]);
            // Debug.Log(""+inputX+" "+inputY);
            float mappedX = MapRange(inputX, udpInputXMin, udpInputXMax, gameXMin, gameXMax);
            float mappedY = MapRange(inputY, udpInputYMin, udpInputYMax, gameYMin, gameYMax);
            // Debug.Log(""+mappedX+" "+mappedY);
            rectTransform.localPosition = new Vector2(mappedX, mappedY);
        }else{
            cursor.SetActive(false);
        }

    }

    float MapRange(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        float normalizedValue = Mathf.InverseLerp(fromMin, fromMax, value);
        return Mathf.Lerp(toMin, toMax, normalizedValue);
    }
}
