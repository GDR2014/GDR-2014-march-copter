using UnityEngine;

public class Player : MonoBehaviour {

    public float 
        HoverForce = 10.0f,
        MaxHoverVelocity = 10f;

    private GameManager gameManager;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if( Input.GetMouseButtonDown( 0 ) || Input.GetMouseButtonUp( 0 )) StopAcceleration();
        if( Input.GetMouseButton( 0 ) && !gameManager.IsPaused ) Hover(); // TODO: Hover should be called in fixed update
    }

    void Hover() {
        rigidbody2D.AddForce(new Vector2(0, HoverForce));
        rigidbody2D.velocity = Vector2.ClampMagnitude( rigidbody2D.velocity, MaxHoverVelocity );
    }

    void StopAcceleration() {
        rigidbody2D.velocity = new Vector2();
    }

    void OnTriggerEnter2D( Collider2D c ) {
        switch( c.tag ) {
            case "TerrainQuad":
                gameManager.Pause(); // TODO: Play animation and show score
                break;
        }
    }
}
