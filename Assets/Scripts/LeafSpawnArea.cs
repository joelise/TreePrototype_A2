using UnityEngine;

public class LeafSpawnArea : MonoBehaviour
{
    public float outerRadius = 3f;       // radius of the pipe wall
    public float spawnHeight = 5f;       // height where leaves spawn

    [Range(0f, 180f)]
    public float angleRange = 30f;       // degrees around player where leaves can spawn

    // Call this every time you want a leaf to spawn
    // playerAngle = the current angle of the player around the pipe (in degrees)
    public Vector3 GetSpawnPoint(float playerAngle)
    {
        // pick random angle around the player
        float halfRange = angleRange / 2f;
        float randomAngle = playerAngle + Random.Range(-halfRange, halfRange);
        float rad = randomAngle * Mathf.Deg2Rad;

        // spawn at outer radius (pipe wall)
        float x = Mathf.Cos(rad) * outerRadius;
        float z = Mathf.Sin(rad) * outerRadius;

        // fixed height above player
        float y = spawnHeight;

        Vector3 localPoint = new Vector3(x, y, z);
        return transform.TransformPoint(localPoint);
    }
}
