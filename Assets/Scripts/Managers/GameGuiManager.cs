using UnityEngine;

public class GameGuiManager : MonoBehaviour {
    public ResetButton ResetButton;

    public void SetResetButtonVisibility( bool visible ) {
        ResetButton.Enabled = visible;
    }
}