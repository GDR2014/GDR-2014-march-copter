using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour {

    public TerrainSegment ObstaclePrefab;
    public TerrainSegment TerrainSegmentPrefab;
    private PostitionGenerator PosGen;

    public float 
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
        PosGen = new PostitionGenerator();
        InvokeRepeating( "SpawnSegment", 0.3f, width / speed );
        Invoke( "StartObstacleRoutine", 2 + Random.Range( ObstacleDelayMin, ObstacleDelayMax ) );
    }

    void StartObstacleRoutine() { StartCoroutine( SpawnObstacleRoutine() ); }

    IEnumerator SpawnObstacleRoutine() {
        SpawnObstacle();
        float delay = Random.Range( ObstacleDelayMin, ObstacleDelayMax );
        yield return new WaitForSeconds(delay);
        StartCoroutine( SpawnObstacleRoutine() );
    }

    private TerrainSegment SpawnObstacle() {
        Vector2 pos = transform.position;
        pos.y = Random.Range( -PostitionGenerator.MaxDeviation, PostitionGenerator.MaxDeviation );
        return ObstaclePrefab.Spawn( pos );
    }

    private TerrainSegment SpawnSegment() {
        Vector2 pos = transform.position;
        // TODO: Make better terrain algorithm
        pos.y = PosGen.Next;
        //pos.y = MaxDeviation * (Mathf.PerlinNoise( Time.time * 2, 0 )-.5f);
        //pos.y += (float) Math.Sin( (Time.timeSinceLevelLoad * 2 - .3) * MaxDeviation );
        return TerrainSegmentPrefab.Spawn( pos );
    }
    
    public class PostitionGenerator {
        public static float MaxDeviation = 1.3f;
        private int segments = 5, currentSegment;
        private Vector2 Start, End;
        protected Vector2 P2 {
            get {
                return new Vector2(End.x/2, Start.y);
            }
        }
        protected Vector2 P3 {
            get {
                return new Vector2(End.x/2, End.y);
            }
        }
        public float Next {
            get {
                currentSegment++;
                if(currentSegment == segments) newCurve();
                float t = (float)currentSegment / segments;
                return CalculateBezierPoint( t, Start, P2, P3, End ).y;
            }
        }

        private void newCurve() {
            currentSegment = 0;
            Start = End;
            Start.x = 0;
            End = new Vector2( 10, Random.Range( -MaxDeviation, MaxDeviation ) );
        }

        // Method taken from http://devmag.org.za/2011/04/05/bzier-curves-a-tutorial/
        private Vector2 CalculateBezierPoint( float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3 ) {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            Vector2 p = uuu * p0; //first term
            p += 3 * uu * t * p1; //second term
            p += 3 * u * tt * p2; //third term
            p += ttt * p3; //fourth term

            return p;
        }

    }
}