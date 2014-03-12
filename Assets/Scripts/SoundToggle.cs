using UnityEngine;

[RequireComponent(typeof(GUITexture))]
public class SoundToggle : GuiClickScript {

    public Texture2D OnSprite, OffSprite;
    AudioSource[] AudioSources;
    private GUITexture texture;

    public bool IsMuted { get; set; }

    new void Awake() {
        base.Awake();
        IsMuted = PlayerPrefs.GetInt( "muted", 0 ) > 0;
        AudioSources = FindObjectsOfType<AudioSource>();
        texture = guiTexture;
    }

    void Start() {
        SetSprite();
        SetVolume();
    }

    void ToggleSound() {
        IsMuted = !IsMuted;
        SetVolume();
        SetSprite();
        PlayerPrefs.SetInt( "muted", IsMuted ? 1 : 0 );
    }

    void SetVolume() {
        foreach( var source in AudioSources )
            source.volume = IsMuted ? 0.0f : 1.0f;
    }

    void SetSprite() {
        texture.texture = IsMuted ? OffSprite : OnSprite;
    }

    protected override void OnClick() {
        ToggleSound();
    }
}
