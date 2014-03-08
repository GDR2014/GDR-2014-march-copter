using System;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public TerrainSegment TerrainSegmentPrefab;
    private float width, speed;

    void Awake() {
        TerrainSegmentPrefab.CreatePool();
        width = TerrainSegmentPrefab.Width;
        width = width - ( width * TerrainSegmentPrefab.OverlapPercentage ); // Apply overlap to reduce jitter
        speed = TerrainSegmentPrefab.MoveSpeed;
        KickstartTerrainPool(30); // Spawn and recycle, in order to give the pool time to initialize before real spawning
    }

    private void Start() {
        InvokeRepeating( "SpawnSegment", 0.3f, width / speed ); // "0.1f" can't be "0.0f", or it would spawn like three segments on first invoke. :/
    }

    private TerrainSegment SpawnSegment() {
        Vector2 pos = transform.position;
        pos.y += (float) Math.Sin( Time.time * 1.3 );
        //pos.y += Random.Range( -1.3f, 1.3f ); // TODO: Make better terrain algorithm
        return ObjectPool.Spawn( TerrainSegmentPrefab, pos );
    }

    private void KickstartTerrainPool( int count ) {
        TerrainSegment[] b = new TerrainSegment[count];
        for( int i = 0; i < count; i++ ) b[i] = SpawnSegment();
        foreach( TerrainSegment segment in b ) segment.Recycle();
    }
}