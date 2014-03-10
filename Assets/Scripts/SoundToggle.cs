using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SoundToggle : MonoBehaviour {

    private bool _muted;
    public bool IsMuted {
        get {
            return _muted;
        }
        set {
            _muted = value;
            PlayerPrefs.SetInt("muted", _muted ? 0 : 1);
        }
    }
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
    }

    void SetVolume() {
        foreach( var source in AudioSources )
            source.volume = IsMuted ? 0.0f : 1.0f;
    }

    void SetSprite() {
        spriteRenderer.sprite = IsMuted ? OffSprite : OnSprite;
    }

    void OnMouseDown() {
        ToggleSound();
    }
}
