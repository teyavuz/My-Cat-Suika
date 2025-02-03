using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchInputHandler : MonoBehaviour
{
    private Vector2 _startPos;

    void Update()
    {
        if (Touch.activeFingers.Count > 0)
        {
            var touch = Touch.activeFingers[0].currentTouch;

            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
                _startPos = touch.screenPosition;

            else if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            {
                Vector2 delta = touch.screenPosition - _startPos;
                UserInput.MoveInput = new Vector2(delta.x / Screen.width * 2, 0);
            }
        }
        else
            UserInput.MoveInput = Vector2.zero;
    }
}