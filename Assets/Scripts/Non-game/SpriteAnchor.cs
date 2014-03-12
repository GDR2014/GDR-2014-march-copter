using UnityEngine;

public class SpriteAnchor : MonoBehaviour {

    public enum Anchor {
        TopLeft, TopCenter, TopRight,
        MidLeft, MidCenter, MidRight,
        BotLeft, BotCenter, BotRight
    }

    public Anchor anchor = Anchor.MidCenter;
    protected int halfWidth, halfHeight;
    public Vector2 CenterPos;

    void Awake() {
        halfWidth = Screen.width / 2;
        halfHeight = Screen.height / 2;
    }

    void Update() {
        float anchX = 0, anchY = 0;
        switch( anchor ) {
            case Anchor.TopLeft:
                anchX = -halfWidth;
                anchY = halfHeight;
                break;
            case Anchor.TopCenter:
                anchX = 0;
                anchY = halfHeight;
                break;
            case Anchor.TopRight:
                anchX = halfWidth;
                anchY = halfHeight;
                break;
            case Anchor.MidLeft:
                anchX = -halfWidth;
                anchY = 0;
                break;
            case Anchor.MidCenter:
                anchX = 0;
                anchY = 0;
                break;
            case Anchor.MidRight:
                anchX = halfWidth;
                anchY = 0;
                break;
            case Anchor.BotLeft:
                anchX = -halfWidth;
                anchY = -halfHeight;
                break;
            case Anchor.BotCenter:
                anchX = 0;
                anchY = -halfHeight;
                break;
            case Anchor.BotRight:
                anchX = halfWidth;
                anchY = -halfHeight;
                break;
        }
        Vector2 newPos = new Vector3(anchX + CenterPos.x, anchY + CenterPos.y);
        FindObjectOfType<Camera>().ScreenToWorldPoint( newPos );
        transform.position = newPos;
    }
}
