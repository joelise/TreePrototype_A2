using UnityEngine;

public class MissBoxTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public LeafTrigger leafTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leaf"))
        {
            if (leafTrigger.CanScore == true)
            {
                gameManager.LeafMissed(other.gameObject);
                Debug.Log("Missed");
            }
           
        }
    }
}
