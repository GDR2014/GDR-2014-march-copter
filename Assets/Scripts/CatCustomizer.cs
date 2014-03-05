using System;
using UnityEngine;

public class CatCustomizer : MonoBehaviour {

    public Transform cat;
    protected Transform body, head, legs, tail;

    public Sprite[] BodyPatterns;

    public enum CatPart {
        BODY,
        HEAD
    };

    void Start() {
        body = cat.FindChild( "CustomBody" );
        head = cat.FindChild( "CustomHead" );
        legs = cat.FindChild( "Legs" );
        tail = cat.FindChild( "Tail" );
        AddPattern(BodyPatterns[0], CatPart.BODY, Color.magenta);
    }

    public void AddPattern( Sprite pattern, CatPart part, Color color ) {
        string sortingLayer = GetSortingLayer( part );
        Transform p = GetPartTransform( part );

        GameObject c = new GameObject(pattern.name);
        SpriteRenderer r = c.AddComponent<SpriteRenderer>();
        r.sprite = pattern;
        r.color = color;
        r.sortingLayerName = sortingLayer;
        r.sortingOrder = p.childCount;
        c.transform.parent = p;
        c.transform.localPosition = new Vector3(0,0,0);
    }

    public void RemovePattern( Sprite pattern, CatPart part ) {
        Transform t = GetPartTransform( part );
        Transform c = t.FindChild( pattern.name );
        c.Recycle(); // TODO: Might want to call recycle on c.spriteRenderer..?
    }

    protected Transform GetPartTransform( CatPart part ) {
        Transform p; // Parent part
        switch ( part ) {
            case CatPart.BODY:
                p = body;
                break;
            case CatPart.HEAD:
                p = head;
                break;
            default:
                throw new ArgumentOutOfRangeException( "part" );
        }
        return p;
    }

    protected string GetSortingLayer( CatPart part ) {
        string sortingLayer = "";
        switch ( part ) {
            case CatPart.BODY:
                sortingLayer = "CatBody";
                break;
            case CatPart.HEAD:
                sortingLayer = "CatHead";
                break;
            default:
                throw new ArgumentOutOfRangeException( "part" );
        }
        return sortingLayer;
    }
}