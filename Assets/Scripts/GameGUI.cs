using UnityEngine;

public class GameGUI : MonoBehaviour {

    public float
        NativeWidth = 960.0f,
        NativeHeight = 540.0f;

    protected Vector3 matrixVector;

    protected string debugControlHelp = "Press <R> to reset";

    void Awake() {
        matrixVector = new Vector3( Screen.width / NativeWidth, Screen.height / NativeHeight, 1 );
    }

    void OnGUI() {
        GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, matrixVector );
        GUI.Label(new Rect(10, 10, 150, 40), debugControlHelp );
    }
}
