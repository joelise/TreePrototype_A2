using UnityEngine;

public class LeafTrigger : MonoBehaviour
{
    public bool CanScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Leaf"))
        {
            CanScore = true;
        }
        else
        {
            CanScore = false;
        }
    }
}
