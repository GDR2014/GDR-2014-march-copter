using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SoundToggle : MonoBehaviour {

    public bool IsMuted { get; set; }
    public Sprite OnSprite, OffSprite;
    AudioSource[] AudioSources;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        IsMuted = PlayerPrefs.GetInt( "muted", 0 ) > 0;
        AudioSources = FindObjectsOfType<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        SetSprite();
        SetVolume();
    }

    void ToggleSound() {
        IsMuted = !IsMuted;
        SetVolume();
        SetSprite();
        PlayerPrefs.SetInt("muted", IsMuted ? 1 : 0);
    }

    void SetVolume() {
        foreach( var source in AudioSources )
            source.volume = IsMuted ? 0.0f : 1.0f;
    }

    void SetSprite() {
        spriteRenderer.sprite = IsMuted ? OffSprite : OnSprite;
    }
}
