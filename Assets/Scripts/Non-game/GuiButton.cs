using UnityEngine;

[RequireComponent(typeof(GUITexture))]
public abstract class GuiButton : GuiClickScript {

    protected GUITexture tex;
    public Texture2D Texure, DownTexture;
    public AudioClip ClickSound;
    public bool ReactToClick, ReactToHeld, ReactToRelease;
    protected SoundToggle sound;
    public GUIElement[] GuiElements;
    public bool AutoPopulateGUIElements = true;

    private bool _enabled;
    public bool Enabled {
        get { return _enabled; }
        set {
            _enabled = value;
            foreach ( var gui in GuiElements ) { gui.enabled = _enabled; }
        }
    }


    new void Awake() {
        base.Awake();
        if( AutoPopulateGUIElements ) GuiElements = GetComponents<GUIElement>();
        tex = GetComponent<GUITexture>();
        element = tex;
        sound = FindObjectOfType<SoundToggle>();
    }

    public abstract void ClickAction();

    private void React() {
        // The sound doesn't work when Time.timeScale == 0;
        if( ClickSound != null && !sound.IsMuted ) AudioSource.PlayClipAtPoint(ClickSound, new Vector3(0,0,0));
        ClickAction();
    }

    protected override void OnClick() {
        if( !Enabled ) return;
        tex.texture = DownTexture;
        if( ReactToClick ) React();
    }

    protected override void OnHeld() {
        if ( !Enabled ) return;
        if ( ReactToHeld ) React();
    }

    protected override void OnReleased() {
        if ( !Enabled ) return;
        tex.texture = Texure;
        if( ReactToRelease ) React();
    }
}