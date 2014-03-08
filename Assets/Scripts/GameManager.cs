using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool IsPaused;
    protected float previousTimeScale;

    void Start() {
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

    IEnumerator WaitForFirstInput() {
        while( IsPaused ) {
            if ( Input.GetMouseButton( 0 ) ) Unpause();
            yield return null;
        }
    }
}
