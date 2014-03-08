using UnityEngine;

public class Player : MonoBehaviour {

    public float 
        HoverForce = 500.0f,
        MaxHoverVelocity = 10f;

    private GameManager gameManager;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if( Input.GetMouseButton( 0 ) && !gameManager.IsPaused ) Hover();
    }

    void Hover() {
        rigidbody2D.AddForce(new Vector2(0, HoverForce));
        rigidbody2D.velocity = Vector2.ClampMagnitude( rigidbody2D.velocity, MaxHoverVelocity );
    }

    void OnTriggerEnter2D( Collider2D c ) {
        switch( c.tag ) {
            case "TerrainQuad":
                gameManager.Pause();
                break;
        }
    }
}
