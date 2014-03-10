using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public static KeyCode HoverKey = KeyCode.Space;
    public static bool HoverPressed { get { return Input.GetMouseButtonDown( 0 ) || Input.GetKeyDown( HoverKey ) || TouchPressed(); } }
    public static bool HoverReleased { get { return Input.GetMouseButtonUp( 0 ) || Input.GetKeyUp( HoverKey ) || TouchReleased(); } }
    public static bool HoverHeld { get { return Input.GetMouseButton( 0 ) || Input.GetKey( HoverKey ) || Input.touchCount > 0; } }

    protected static bool TouchPressed() {
        return Input.touches.Any( touch => touch.phase == TouchPhase.Began );
    }

    protected static bool TouchReleased() {
        return Input.touches.Any( touch => touch.phase == TouchPhase.Ended );
    }
}