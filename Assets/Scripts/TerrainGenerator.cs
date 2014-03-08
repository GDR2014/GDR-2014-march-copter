using System;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public TerrainSegment TerrainSegmentPrefab;
    protected float width, speed;

    void Awake() {
        TerrainSegmentPrefab.CreatePool();
        width = TerrainSegmentPrefab.Width;
        width = width - ( width * TerrainSegmentPrefab.OverlapPercentage ); // Apply overlap to reduce jitter
        speed = TerrainSegmentPrefab.MoveSpeed;
    }

    private void Start() {
        InvokeRepeating( "SpawnSegment", 0.3f, width / speed ); 
    }

    private TerrainSegment SpawnSegment() {
        Vector2 pos = transform.position;
        // TODO: Make better terrain algorithm
        pos.y += (float) Math.Sin( (Time.timeSinceLevelLoad * 2 - .3) * 1.3 );
        return ObjectPool.Spawn( TerrainSegmentPrefab, pos );
    }
}