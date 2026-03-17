using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public float InnerRadius = 2f;
    public float OuterRadius = 3f;

    public float Height = 5f;
    public float MinHeight = 0f;
    public float MaxHeight = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetSpawnPoint()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float radius = OuterRadius;  // fixed to outer wall

        float y = Random.Range(MinHeight, MaxHeight);

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        Vector3 localPoint = new Vector3(x, y, z);

        return transform.TransformPoint(localPoint);
    }

    private void OnDrawGizmos()
    {
        DrawCircle(InnerRadius, MinHeight, Color.red);
        DrawCircle(InnerRadius, MaxHeight, Color.red);

        DrawCircle(OuterRadius, MinHeight, Color.green);
        DrawCircle(OuterRadius, MaxHeight, Color.green);
    }

    void DrawCircle(float radius, float height, Color color)
    {
        Gizmos.color = color;

        int segments = 50;
        float step = 360f / segments;

        Vector3 prevPoint = GetPoint(radius, height, 0);

        for (int i = 1; i <= segments; i++)
        {
            float angle = Mathf.Deg2Rad * step * i;
            Vector3 nextPoint = GetPoint(radius, height, angle);

            Gizmos.DrawLine(prevPoint, nextPoint);
            prevPoint = nextPoint;
        }
    }

    Vector3 GetPoint(float radius, float height, float angle)
    {
        Vector3 localPoint = new Vector3(
            Mathf.Cos(angle) * radius,
            height,
            Mathf.Sin(angle) * radius
        );

        return transform.TransformPoint(localPoint);
    }
}
