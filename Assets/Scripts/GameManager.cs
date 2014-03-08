using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool Paused;
    protected float previousTimeScale;

    void Awake() {
        Pause();
    }

    void Start() {
        StartCoroutine( WaitForFirstInput() );
    }

    public void Pause() {
        previousTimeScale = Time.timeScale;
        Paused = true;
        Time.timeScale = 0;
    }

    public void Unpause() {
        Time.timeScale = previousTimeScale;
        Paused = false;
    }

    IEnumerator WaitForFirstInput() {
        while( Paused ) if ( Paused && Input.GetMouseButton( 0 ) ) Unpause(); yield break;
    }
}
