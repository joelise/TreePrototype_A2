using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform Tree;
    public float Radius = 5f;
    public float RotationSpeed = 90f;
    public float MoveSmooth = 5f;

    private float angle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateAround();
    }

    public void RotateAround()
    {
        float horizontal = 0f;
        if (Input.GetKey(KeyCode.A))
            horizontal = -1f;
        if (Input.GetKey(KeyCode.D))
            horizontal = 1f;

        angle += horizontal * RotationSpeed * Time.deltaTime;
        if (angle >= 360f)
            angle -= 360f;
        if (angle < 0f)
            angle += 360f;

        float rad = angle * Mathf.Deg2Rad;
        Vector3 targetPos = Tree.position + new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad)) * Radius;

        transform.position = Vector3.Lerp(transform.position, targetPos, MoveSmooth * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(Tree.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, MoveSmooth * Time.deltaTime);

    }
}
