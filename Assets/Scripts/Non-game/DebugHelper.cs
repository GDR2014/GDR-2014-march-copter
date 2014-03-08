using UnityEngine;

public class DebugHelper : MonoBehaviour {

    private GameManager gameManager;
    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update() {
        if( Input.GetKeyDown( KeyCode.R )) Application.LoadLevel(0);
        if( Input.GetKeyDown(KeyCode.P)) gameManager.TogglePause();
    }

}
