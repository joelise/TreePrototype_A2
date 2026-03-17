using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Health")]
    public int StartHealth;
    public int CurrentHealth;
    public bool Alive;

    [Header("Score")]
    public int Score;
    public int StartingScore = 0;

    [Header("Leaves")]
    public BoxCollider SpawnArea;
    public GameObject Leaf;
    public bool HasSpawned;
    public float timer = 0f;
    public BoxCollider MissBox;
    public ScoreUI UI;
    
    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        StartHealth = 3;
        CurrentHealth = StartHealth;
        Alive = true;
        Score = StartingScore;
        //UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Alive)
        {
            float delay = 3f;
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                SpawnInArea();
                timer = 0f;
            }
        }

        if (CurrentHealth <= 0)
        {
            Alive = false;
            GameEnd();
            UI.Show();
            Time.timeScale = 0;
        }
       
        

    }

    public Vector3 RandomSpawnPoint(BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;

        Vector3 point = new Vector3(Random.Range(-extents.x, extents.x), Random.Range(-extents.y, extents.y), 0f);

        return boxCollider.transform.TransformPoint(point);
    }

    public void SpawnInArea()
    {
        Vector3 randomPoint = RandomSpawnPoint(SpawnArea);
        Instantiate(Leaf, randomPoint, Quaternion.identity);
        HasSpawned = true;
    }

    public void LeafMissed(GameObject leaf)
    {
        CurrentHealth--;
        Destroy(leaf);
        Debug.Log("Destroyed");
    }

   
    public void GameEnd()
    {
       // Alive = false;
        Debug.Log("Game Over");
        Debug.Log("Your Score:" + Score);
        
    }

    public void CaughtLeaf(GameObject leaf)
    {
        Score++;
        //UpdateScoreText();
        Destroy(leaf);
        Debug.Log("Plus 1");
    
    }

    public void UpdateScoreText()
    {
        
    }

}
