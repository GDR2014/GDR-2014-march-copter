using UnityEngine;

public class InputManager : MonoBehaviour {
    public static KeyCode HoverKey = KeyCode.Space;
    public static bool HoverPressed { get { return Input.GetMouseButtonDown( 0 ) || Input.GetKeyDown( HoverKey ); } }
    public static bool HoverReleased { get { return Input.GetMouseButtonUp( 0 ) || Input.GetKeyUp( HoverKey ); } }
    public static bool HoverHeld { get { return Input.GetMouseButton( 0 ) || Input.GetKey( HoverKey ); } }
}