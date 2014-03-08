using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    void OnTriggerEnter2D( Collider2D c ) {
        switch( c.gameObject.tag ) {
            case "TerrainQuad": 
                c.gameObject.transform.parent.Recycle();
                break;
        }
    }
}
