using System;
using UnityEngine;

public class GameGUI : MonoBehaviour {

    public float
        NativeWidth = 960.0f,
        NativeHeight = 540.0f;
    public GUIText guitext;
    protected Vector3 matrixVector;

    protected string debugControlHelp = "Press <R> to reset\nPress <P> to pause";

    public int FontSizeScore = 20;
    public Rect
        ScorePosition,
        GameOverScreenPosition;

    void Awake() {
        matrixVector = new Vector3( Screen.width / NativeWidth, Screen.height / NativeHeight, 1 );
    }

    void OnGUI() {
        GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, matrixVector );
        DrawDebugHelpGUI();
        DrawScore();
        if ( GameManager.IsGameOver ) DrawGameOverScreen();
    }

    void DrawScore() {
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.skin.label.fontSize = FontSizeScore;
        GUILayout.BeginArea(ScorePosition);
        DrawTextInLayout( "Score: " + ScoreManager.Score );
        DrawTextInLayout( "Best: " + ScoreManager.Best );
        GUILayout.EndArea();
    }

    void DrawDebugHelpGUI() {
        GUI.skin.label.fontSize = 20;
        GUI.Label( new Rect( 10, 10, 300, 80 ), debugControlHelp );
    }

    void DrawGameOverScreen() {
        // Haxy UI positioning. :(
        Rect realRect = new Rect(0, GameOverScreenPosition.y, NativeWidth, GameOverScreenPosition.height);
        GUILayout.BeginArea(realRect);
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                string gameOverString = String.Format( "You crashed!\nScore: {0}\nBest: {1}", ScoreManager.Score, ScoreManager.Best );
                GUILayout.Box( gameOverString, GUILayout.Width(GameOverScreenPosition.width) );
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if ( GUILayout.Button( "Retry", GUILayout.Width( GameOverScreenPosition.width ) ) ) GameManager.ResetGame();
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    void DrawTextInLayout( string text ) {
        GUI.skin.label.wordWrap = false;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(text);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}
