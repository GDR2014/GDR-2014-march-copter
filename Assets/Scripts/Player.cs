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
        HandleInput();
    }

    void HandleInput() {
        if ( InputManager.HoverPressed || InputManager.HoverReleased ) StopAcceleration();
        if ( InputManager.HoverHeld && !GameManager.IsPaused ) Hover(); // TODO: Hover should be called in fixed update
    }

    void Hover() {
        rigidbody2D.AddForce(new Vector2(0, HoverForce));
        rigidbody2D.velocity = Vector2.ClampMagnitude( rigidbody2D.velocity, MaxHoverVelocity );
    }

    void StopAcceleration() {
        rigidbody2D.velocity = new Vector2();
    }

    void Die() {
        // TODO: Play death animation
        gameManager.GameOver();
    }

    void OnTriggerEnter2D( Collider2D c ) {
        switch( c.tag ) {
            case "Obstacle":
            case "TerrainQuad":
                Die();
                break;
        }
    }
}
