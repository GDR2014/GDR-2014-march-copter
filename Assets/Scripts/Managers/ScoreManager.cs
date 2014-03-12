using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public float ScoreDelay = 0.01f;
    public int ScorePerDistance = 1;
    public static int Score { get; set; }
    public static int Best { get; set; }

    void Start() {
        Reset();
        InvokeRepeating("IncreaseByDistance", 0.1f, ScoreDelay);
    }

    void IncreaseByDistance() {
        IncreaseScore(ScorePerDistance);
    }

    void IncreaseScore( int amount ) {
        Score += amount;
        if( Score > Best ) Best = Score;
    }

    void Reset() {
        Score = 0;
    }
}
