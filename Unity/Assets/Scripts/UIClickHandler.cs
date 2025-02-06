using UnityEngine;
using UnityEngine.UI;

public class UIClickHandler : MonoBehaviour
{
    public Button playButton;
    public Button menuExitButton;
    public Button resumeButton;
    public Button pauseExitButton;
    public RectTransform cursor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isPaused: "+GameStateManager.isPaused + " isLevel: "+GameStateManager.isLevel);
        if (GameStateManager.isMenu && CursorHandler.isClick){
            if (IsHovering(cursor, playButton.GetComponent<RectTransform>())){
                playButton.onClick.Invoke();
            }else if (IsHovering(cursor, menuExitButton.GetComponent<RectTransform>())){
                menuExitButton.onClick.Invoke();
            }
        }else if(GameStateManager.isPaused && CursorHandler.isClick){
            if (IsHovering(cursor, resumeButton.GetComponent<RectTransform>())){
                // Debug.Log("Resume Called");
                resumeButton.onClick.Invoke();
            }else if (IsHovering(cursor, pauseExitButton.GetComponent<RectTransform>())){
                pauseExitButton.onClick.Invoke();
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
