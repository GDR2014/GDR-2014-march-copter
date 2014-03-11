using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class ClickScript : MonoBehaviour {
    
    protected virtual void OnClick() { Debug.Log("Super click called");}
    protected virtual void OnReleased() { Debug.Log( "Super released called" ); }
    protected virtual void OnHeld() { Debug.Log( "Super held called" ); }

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