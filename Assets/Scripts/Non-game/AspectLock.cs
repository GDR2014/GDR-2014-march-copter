using System;
using UnityEngine;

[RequireComponent(typeof(GUITexture))]
public class AspectLock : MonoBehaviour {

    public enum BaseDimension{ Width, Height }

    public BaseDimension baseDimension;
    protected GUITexture tex;

    private int
        texWidth, texHeight,
        scrWidth, scrHeight;
    
    private float texAspect, scrAspect;

    public float size;

    void Start() {
        Recalculate();
    }

    [ExecuteInEditMode]
    public void Recalculate() {
        tex = guiTexture;
        texWidth = tex.texture.width;
        texHeight = tex.texture.height;
        texAspect = (float) texWidth / texHeight;
        scrWidth = Screen.width;
        scrHeight = Screen.height;
        scrAspect = (float)scrWidth / scrHeight;
        Debug.Log("ScrWidth: " + scrWidth);
        Debug.Log("ScrHeight: " + scrHeight);
        float a = texAspect * scrAspect;
        Vector2 scl = transform.localScale;
        switch( baseDimension ) {
            case BaseDimension.Width:
                scl.x = size;
                scl.y = a * size;
                break;
            case BaseDimension.Height:
                scl.x = size / a;
                scl.y = size;
                break;
        }
        Debug.Log("Scl: " + scl);
        transform.localScale = scl;
    }
}
