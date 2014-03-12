using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameGuiManager guiManager;

    public static bool 
        IsPaused,
        IsGameOver;

    protected float previousTimeScale;

    void Start() {
        IsGameOver = false;
        Time.timeScale = 1;
        Pause();
        StartCoroutine( WaitForFirstInput() );
    }

    public void Pause() {
        previousTimeScale = Time.timeScale;
        IsPaused = true;
        Time.timeScale = 0;
    }

    public void Unpause() {
        Time.timeScale = previousTimeScale;
        IsPaused = false;
    }

    public void TogglePause() {
        if( IsPaused ) Unpause();
        else Pause();
    }

    public void GameOver() {
        Pause();
        guiManager.SetResetButtonVisibility(true);
        IsGameOver = true;
    }

    public static void ResetGame() {
        Application.LoadLevel(0);
    }

    IEnumerator WaitForFirstInput() {
        while( IsPaused ) {
            if ( InputManager.HoverHeld ) Unpause();
            yield return null;
        }
    }
}
