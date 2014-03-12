using UnityEngine;

[RequireComponent(typeof(GUIElement))]
public class GuiClickScript : MonoBehaviour {
    protected virtual void OnClick() { }
    protected virtual void OnReleased() { }
    protected virtual void OnHeld() { }

    protected bool IsClicked { get { return Input.GetMouseButtonDown( 0 ) && MouseIsOver; } }
    protected bool IsReleased { get { return Input.GetMouseButtonUp( 0 ) && MouseIsOver; } }
    protected bool IsHeld { get { return Input.GetMouseButton( 0 ) && MouseIsOver; } }

    protected GUIElement element;

    protected void Awake() {
        element = GetComponent<GUIElement>();
    }

    protected void Update() {
        if ( IsClicked ) OnClick();
        if ( IsReleased ) OnReleased();
        if ( IsHeld ) OnHeld();
    }

    protected bool MouseIsOver {
        get {
            Vector2 mousepos = Input.mousePosition;
            return element.HitTest(mousepos);
        }
    }
}
