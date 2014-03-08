using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    void OnTriggerEnter2D( Collider2D c ) {
        switch( c.gameObject.tag ) {
            case "TerrainQuad": 
                c.gameObject.transform.parent.Recycle();
                break;
            case "Obstacle":
                Debug.Log("Recycling obstacle..");
                c.gameObject.transform.Recycle();
                break;
        }
    }
}
