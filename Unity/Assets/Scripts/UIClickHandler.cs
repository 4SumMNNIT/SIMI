using UnityEngine;
using UnityEngine.UI;

public class UIClickHandler : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public RectTransform cursor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("isPaused: "+GameStateManager.isPaused + " isLevel: "+GameStateManager.isLevel);
        if (GameManager.state != GameManager.GameState.level && CursorHandler.isClick){
            if (IsHovering(cursor, button1.GetComponent<RectTransform>())){
                button1.onClick.Invoke();
            }else if (IsHovering(cursor, button2.GetComponent<RectTransform>())){
                button2.onClick.Invoke();
            }
        }
    }

    bool IsHovering(RectTransform cursor, RectTransform target)
    {
        Vector2 localPoint;
        
        // Convert the cursor's screen point to local space of the target UI element
        RectTransformUtility.ScreenPointToLocalPointInRectangle(target, cursor.position, null, out localPoint);

        // Check if the cursor's position is within the target's rectangle
        return target.rect.Contains(localPoint);
    }
}
