using UnityEngine;

public class ResetButton : GuiButton {
    public override void ClickAction() { Application.LoadLevel(Application.loadedLevel); }
}
