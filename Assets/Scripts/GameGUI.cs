using UnityEngine;

public class GameGUI : MonoBehaviour {

    public float
        NativeWidth = 960.0f,
        NativeHeight = 540.0f;

    protected Vector3 matrixVector;

    void Awake() {
        matrixVector = new Vector3( Screen.width / NativeWidth, Screen.height / NativeHeight );
    }

    void OnGUI() {
        GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, matrixVector );
    }
}
