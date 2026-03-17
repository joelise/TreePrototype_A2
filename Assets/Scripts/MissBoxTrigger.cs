using UnityEngine;

public class MissBoxTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leaf"))
        {
            gameManager.LeafMissed(other.gameObject);
            Debug.Log("Missed");
        }
    }
}
