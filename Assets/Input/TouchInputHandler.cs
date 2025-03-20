using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchInputHandler : MonoBehaviour
{
    private Vector2 _startPos;
    private bool _isDragging = false;
    [SerializeField] private float dragThreshold = 20f;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (Touch.activeFingers.Count > 0)
        {
            var touch = Touch.activeFingers[0].currentTouch;
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                _startPos = touch.screenPosition;
                _isDragging = false;
                UserInput.MoveInput = Vector2.zero;
            }
            else if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            {
                Vector2 delta = touch.screenPosition - _startPos;
                if (Mathf.Abs(delta.x) > dragThreshold)
                {
                    _isDragging = true;
                    UserInput.MoveInput = new Vector2(delta.x / Screen.width * 2, 0);
                }
                else
                {
                    UserInput.MoveInput = Vector2.zero;
                }
            }
            else if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended)
            {
                if (!_isDragging)
                {
                    UserInput.IsThrowPressed = true;
                }
                UserInput.MoveInput = Vector2.zero;
            }
        }
        else
        {
            UserInput.MoveInput = Vector2.zero;
        }
    }
}
