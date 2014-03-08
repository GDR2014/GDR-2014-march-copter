using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour {

    public TerrainSegment ObstaclePrefab;
    public TerrainSegment TerrainSegmentPrefab;
    public float 
        MaxDeviation = 1.3f,
        ObstacleDelayMin = 1.5f,
        ObstacleDelayMax = 5.0f;

    protected float width, speed;

    void Awake() {
        TerrainSegmentPrefab.CreatePool();
        width = TerrainSegmentPrefab.Width;
        width = width - ( width * TerrainSegmentPrefab.OverlapPercentage ); // Apply overlap to reduce jitter
        speed = TerrainSegmentPrefab.MoveSpeed;
    }

    private void Start() {
        InvokeRepeating( "SpawnSegment", 0.3f, width / speed );
        Invoke( "StartObstacleRoutine", 2 + Random.Range( ObstacleDelayMin, ObstacleDelayMax ) );
    }

    void StartObstacleRoutine() { StartCoroutine( SpawnObstacleRoutine() ); }

    IEnumerator SpawnObstacleRoutine() {
        Debug.Log("Spawning obstacle!");
        SpawnObstacle();
        float delay = Random.Range( ObstacleDelayMin, ObstacleDelayMax );
        yield return new WaitForSeconds(delay);
        StartCoroutine( SpawnObstacleRoutine() );
    }

    private TerrainSegment SpawnObstacle() {
        Vector2 pos = transform.position;
        pos.y = Random.Range( -MaxDeviation, MaxDeviation );
        return ObstaclePrefab.Spawn( pos );
    }

    private TerrainSegment SpawnSegment() {
        Vector2 pos = transform.position;
        // TODO: Make better terrain algorithm
        pos.y += (float) Math.Sin( (Time.timeSinceLevelLoad * 2 - .3) * MaxDeviation );
        return TerrainSegmentPrefab.Spawn( pos );
    }
}