using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class ClickScript : MonoBehaviour {

    protected virtual void OnClick() {}
    protected virtual void OnReleased() {}
    protected virtual void OnHeld() {}

    protected bool IsClicked { get { return Input.GetMouseButtonDown( 0 ) && MouseIsOver; } }
    protected bool IsReleased { get { return Input.GetMouseButtonUp( 0 ) && MouseIsOver; } }
    protected bool IsHeld { get { return Input.GetMouseButton( 0 ) && MouseIsOver; } }

    protected BoxCollider2D hotspot;
    protected Camera cam;

    protected void Start() {
        cam = FindObjectOfType<Camera>();
        hotspot = GetComponent<BoxCollider2D>();
    }

    protected void Update() {
        if( IsClicked ) OnClick();
        if( IsReleased ) OnReleased();
        if( IsHeld ) OnHeld();
    }

    protected bool MouseIsOver {
        get {
            Vector2 mousepos = Input.mousePosition;
            mousepos = cam.ScreenToWorldPoint( mousepos );
            return hotspot.OverlapPoint( mousepos );
        }
    }
}