using UnityEngine;

public class Leaf : MonoBehaviour
{
    public int Value;

    public float FallSpeed = 0.1f;
    public float SwayAmp = 1f;
    public float SwayFreq = 2f;

    private float swayOffset;
    //private float difficultyMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swayOffset = Random.Range(0f, 100f);
        SwayAmp = Random.Range(0.5f, 3f);
        SwayFreq = Random.Range(1f, 3f);
        //FallSpeed = Random.Range(1.5f, 3f);

        //difficultyMultiplier = FindAnyObjectByType<GameManager>().Difficulty;
        
    }

    // Update is called once per frame
    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time, swayOffset) - 0.5f;
        float sway = (Mathf.Sin(Time.time * SwayFreq + swayOffset) + noise) * SwayAmp;

        float bob = Mathf.Sin(Time.time * 2f + swayOffset) * 0.2f;
        float vertical = -FallSpeed * (1f - Mathf.Abs(sway) * 0.05f) + bob;
        transform.position += new Vector3(sway, vertical, 0) * Time.deltaTime;
        transform.Rotate(0, 0, sway * 50f * Time.deltaTime);
        
    }
}
