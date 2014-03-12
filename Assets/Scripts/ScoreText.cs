using System;
using UnityEngine;

[RequireComponent(typeof(GUIText))]
public class ScoreText : MonoBehaviour {
    public enum ScoreType { Current, Best }

    public ScoreType ScoreToDisplay;

    private GUIText text;
    private string prefix;

    void Awake() {
        text = guiText;
        prefix = text.text;
    }
    void Update() {
        string score = "error";
        switch( ScoreToDisplay ) {
            case ScoreType.Current:
                score = ScoreManager.Score.ToString();
                break;
            case ScoreType.Best:
                score = ScoreManager.Best.ToString();
                break;
        }
        text.text = prefix + score;
    }
}
